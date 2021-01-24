public T Load<T>() where T : class, new() => Load(typeof(T)) as T;
just mean you can use the "generic" syntax when accessing in the functions. It's a bit neater than passing in the Type as a method parameter, and also means you get a strongly-typed object back. Another way of writing the above is:
public T Load<T>() where T : class, new()
{
    var type = typeof(T);
    var loaded = Load(type);
    return loaded as T;
}
It's a useful language feature but nothing to do with IoC itself. The IoC magic itself is mostly contained in SettingsModule. This bit:
builder.RegisterInstance(new SettingsReader(_configurationFilePath, _sectionNameSuffix))
    .As<ISettingsReader>()
    .SingleInstance();
tells Autofac to provide a SettingsReader (the RegisterInstance part) whenever anyone requests an ISettingsReader (the As<> bit). .SingleInstance means it will treat the SettingsReader as a singleton: only one of them will be created and that same object is passed to everywhere an ISettingsReader is requested.
This other part
var settings = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => t.Name.EndsWith(_sectionNameSuffix, StringComparison.InvariantCulture))
    .ToList();
settings.ForEach(type =>
{
    builder.Register(c => c.Resolve<ISettingsReader>().LoadSection(type))
        .As(type)
        .SingleInstance();
});
is just a fancy way of automatically telling it what to do whenever it sees a request for DatabaseSettings or UserSettings. As per the original question, *this* is where the Load function is actually called. A simpler way of doing the same would just be:
builder.Register(c => c.Resolve<ISettingsReader>().LoadSection(typeof(DatabaseSettings))).As<DatabaseSettings>();
builder.Register(c => c.Resolve<ISettingsReader>().LoadSection(typeof(UserSettings))).As<UserSettings>();
You could write out the logic for those as "when a DatabaseSettings object is requested (.As<DatabaseSettings>), find an implementation for ISettingsReader, and then call LoadSection on that (the first part)"
Elsewhere in the Container class there's also this:
builder.RegisterType<UserService>().As<IUserService>();
which just tells Autofac what to do for an IUserService.
The result is that where in the main application method we have:
using (var scope = container.BeginLifetimeScope())
{
    var userService = scope.Resolve<IUserService>();
         
		 
Without that main method "knowing" anything about the concrete types it uses, we'll get a fully functioning IUserService back. Internally, Autofac will resolve the chain of dependencies required by plugging all of the constructor parameters for each type in the chain. That might look something like:
 - IUserService requested
       - Resolve UserService
           - Resolve IDatabase
               - return Database
           - Resolve UserSettings
               - Resolve ISettingsReader
                   - return SettingsReader
               - Call LoadSection on ISettingsReader
               - return generated UserSettings object
For your Final Question - yes! However, IoC isn't necessarily what would enable you to do so. It just lets you bind together and access whichever custom classes you'd create to allow saving.
You might create a new interface like
public interface ISettingsWriter
{
    void Save<T>(T settings);
}
And then for some reason you add a method which accesses that in the UserService:
public class UserService : IUserService
{
    private readonly IDatabase _database;
    private readonly UserSettings _userSettings;
    private readonly ISettingsWriter _settingsWriter;
    public UserService(IDatabase database, UserSettings userSettings, ISettingsWriter settingsWriter)
    {
        _database = database;
        _userSettings = userSettings;
        _settingsWriter = settingsWriter;
    }
    public void UpdateUserSettings()
    {
        _settingsWriter.Save(new UserSettings());
    }
 
Using it in this way is a bit simpler than in the original sample code - I'd recommend taking this approach until you get more used to it. It means that the only other thing you'd need to add would be the registration for the settings writer, like:
builder.RegisterType<SettingsWriter>()
    .As<ISettingsWriter>();
