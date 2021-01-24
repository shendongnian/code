    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MessageFilter.Register();
            
            //Your code here
            //...
 
            MessageFilter.Revoke();
        }
    }
