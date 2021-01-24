    public class Plep 
    {
    public string Name { get; set; } = "smew";
    public List<Subs> Subs {get;set;}
    public void SaveToFile(string file)
    {
        using (StreamWriter wrt = new StreamWriter(file))
        {
            wrt.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                //TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            }));
        }
    }
