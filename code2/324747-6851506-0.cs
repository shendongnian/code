    public class EntryManager
    {
    	public EntryManager(Func<ILoader, IEntry> entryFactory, Func<Settings, ILoader> loaderFactory)
        {
            var entrySettings = this.settings.Load();
            foreach(var setting in entrySettings)
            {
                this.entries.Add(entryFactory(loaderFactory(setting)));
            }
        }
    }
    private static ILoader SelectLoader(IEntrySetting settings)
    {
        // your custom loader selection logic
    }
    var builder = new ContainerBuilder();
    builder.RegisterType<EntryManager>();
    builder.RegisterType<Entry>().As<IEntry>();
    builder.Register((c, p) => SelectLoader(p.TypedAs<IEntrySetting>()));
    IContainer container = builder.Build();
    container.Resolve<EntryManager>();
