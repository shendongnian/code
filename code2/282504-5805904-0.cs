    Object 
    Object
    Specific
    class Program
    {
        static void Main()
        {
            Object aSpecific = new Object();
            String nonSpecific = "nonSpecific";
            ISpecific specific = new Specific();
    
            ISomething something = new Something();
    
            something.Go(aSpecific);
            something.Go(nonSpecific);
            something.Go(specific);
    
            Console.ReadKey();
        }
    }
    
    interface ISpecific
    {
        void GoGo();
    }
    
    interface ISomething
    {
        void Go(ISpecific specific)
        void Go(Object o)
    }
    
    Class Specific : ISpecific
    {
        public Specific() { }
    
        public void GoGo()
        {
             Console.WriteLine("Specific");
        }
    }
    
    Class Something : ISomething
    {
        public Something() { }
    
        public void Go(ISpecific specific)
        {
            specific.GoGo()
        }
    
        public void Go(Object o)
        {
            Console.WriteLine("Object");
        }
    }
