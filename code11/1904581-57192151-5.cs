        public class Bar1: FooMethodsBaseClass
        {
            public Bar1(FooSettings fooSettings):base(fooSettings)
            {
    
            }
    
            public override void WriteTag()
            {
                Console.WriteLine("Bar1 " + Settings.Tag);
            }
        }
