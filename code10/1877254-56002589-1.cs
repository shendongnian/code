    public class Der: BaseClass
    {
        public override void BeforeMe()
        {
           Console.WriteLine("Executing BeforeMe of Der class");
        }
    
        public override void AfterMe()
        {
           Console.WriteLine("Executing AfterMe of Der class");
        }
    }
