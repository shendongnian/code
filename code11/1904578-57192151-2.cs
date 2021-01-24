        public class Bar2: FooMethodsBaseClass
        {
            public Bar2(FooSettings fooSettings):base(fooSettings)
            {
    
            }
    
            public override void WriteTag()
            {
                Console.WriteLine("Bar2 " + Settings.Tag);
            }
        }
