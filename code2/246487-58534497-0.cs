    public class JavaScriptSettings
    {
        public JRaw OnLoadFunction { get; set; }
        public JRaw OnUnloadFunction { get; set; }
    }
    JavaScriptSettings settings = new JavaScriptSettings
    {
        OnLoadFunction = new JRaw("OnLoad"),
        OnUnloadFunction = new JRaw("function(e) { alert(e); }")
    };
    
    string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
    
    Console.WriteLine(json);
    // {
    //   "OnLoadFunction": OnLoad,
    //   "OnUnloadFunction": function(e) { alert(e); }
    // }
