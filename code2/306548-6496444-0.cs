    public class FooSettings : ISettings
    {
       //this is where you are linking the settings type to its processor type
       public IProcessor GetProcessor() { return new FooProcessor(this); }
    }
