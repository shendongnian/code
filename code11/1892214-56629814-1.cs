// in assembly Data
interface IAppAPI
{
    void SetData(string data);
    string GetData();
}
// wherever you want. You only need a reference to the Data assembly
class AppAPI : IAppAPI
{
    public string GetData()
    {
        // get and return data
    }
    public void SetData(string data)
    {
        // set data
    }
}
// wherever you want. You only need a reference to the Data assembly
void LoadPlugin(string pluginPath, string pluginTypeIdentifier) 
{
    Assembly pluginAssembly = Assembly.LoadFile(pluginPath);
    Type pluginType = pluginAssembly.GetType(pluginTypeIdentifier);
    IAppAPI plugin = (IAppAPI)Activator.CreateInstance(pluginType);
    plugin.SetData("whatever");
    string whatever = plugin.GetData();
}
You have some assembly (let's call it Data). In this you have the interface for implementing the plugin. Then you can implement it anywhere you'd like. You only have to add a reference to the assembly so it knows what the interface is.  
Now you can have this `LoadPlugin` method which takes the path to an assembly and the full name of the plugin type (eg. `pluginTest.plugin`).  
You can then cast the new instance of that plugin to the interface (because you want those methods).  
Now call your functions or do whatever you want with it.  
Note that I didn't add any error checks. I would highly advise you to check if  
 1. the assembly exists (`File.Exists`)
 2. the type exists (check if the `type == null` or use the exception overloads)
 3. the type is assignable from the interface (`pluginType.IsAssignableFrom(typeof(IAppAPI))`)
 4. the type is a class and has a parameterless constructor and is not static or abstract (`pluginType.IsClass && !pluginType.IsAbstract`). IsAbstract also clears the static part (see [this answer](https://stackoverflow.com/a/1175901/10883465)). For the parameterless constructor see [this question](https://stackoverflow.com/questions/4681031/how-do-i-check-if-a-type-provides-a-parameterless-constructor).
Maybe there are even more checks you could/should do.
