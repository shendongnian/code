    Class Printer
    {
        public event EventHandler Print;
    
        public void Start()
        {
            OnPrint();
        }
        
        protected virtual void OnPrint()
        {
            Print?.Invoke(this,EventArgs.Empty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //When Print is an EventHander
            var printer = new Printer();
            printer.Print += PrintEvent;
            printer.Start();
    
            //If Print was a delegate this is possible, else you get compile time errors 
            printer.Print(null,null); // Events will not allow to have a direct invoke 
            printer.Print = null; //You cannot assign a null to an Event Handler
        }
        private static void PrintEvent(object sender, EventArgs e)
        {
            System.Console.WriteLine("Printing event");
        }
    }
