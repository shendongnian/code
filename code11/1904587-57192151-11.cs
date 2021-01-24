        public class Foo
        {
            public IFooSettings Settings;
    
            public IFooMethodsBaseClass Bar1 { get; }
            public IFooMethodsBaseClass Bar2 { get; }
    
            public Foo(IFooSettings settings)
            {
                Settings = settings;
                Bar1 = new Bar1(Settings);
                Bar2 = new Bar2(Settings);
            }
        }
    
        public class FooSettings: IFooSettings
        {
            public string Tag { get; set; }
    
            public FooSettings(string tag)
            {
                Tag = tag;
            }
    
        }
        public interface IFooSettings
        {
            string Tag { get; set; }
        }
