            public class Foo
            {
                public static FooSettings Settings;
    
                public FooMethods.Bar1 Bar1 { get; private set; }
                public FooMethods.Bar2 Bar2 { get; private set; }
    
                public Foo(FooSettings settings)
                {
                    Settings = settings;
                    Bar1 = new FooMethods.Bar1();
                    Bar2 = new FooMethods.Bar2();
                }
            }
    
            public class FooSettings
            {
                public string Tag { get; set; }
    
                public FooSettings(string tag)
                {
                    Tag = tag;
                }
            }
    
            public class FooMethods
            {
                public class Bar1
                {
                    public void WriteTag()
                    {
                        Console.WriteLine("Bar1 " + Foo.Settings.Tag);
                    }
                }
    
                public class Bar2
                {
                    public void WriteTag()
                    {
                        Console.WriteLine("Bar2 " + Foo.Settings.Tag);
                    }
                }
            }
