    using (ScriptEngine engine = new ScriptEngine("jscript"))
    {
        ParsedScript parsed = engine.Parse("function MyFunc(x){return 1+2+x+My.Num}");
        MyItem item = new MyItem();
        item.Num = 4;
        engine.SetNamedItem("My", item);
        Console.WriteLine(parsed.CallMethod("MyFunc", 3));
    }
    
    [ComVisible(true)] // Script engines are COM components.
    public class MyItem
    {
        public int Num { get; set; }
    }
