    public class Bar2: FooMethodsBaseClass
    {
        public Bar2(IFooSettings fooSettings):base(fooSettings)
        {
    
        }
    
        public override void WriteTag()
        {
            Console.WriteLine("Bar2 " + Settings.Tag);
        }
    }
