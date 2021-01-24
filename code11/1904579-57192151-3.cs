        public class Foo
        {
            public FooSettings Settings;
    
            public FooMethodsBaseClass Bar1 { get; }
            public FooMethodsBaseClass Bar2 { get; }
    
            public Foo(FooSettings settings)
            {
                Settings = settings;
                Bar1 = new Bar1(Settings);
                Bar2 = new Bar2(Settings);
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
