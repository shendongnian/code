    class Program
        {
            static void Main(string[] args)
            {
                var d = new Derived();
                d.Boom += new EventHandler(HandleBoom);
    
                d.TriggerBoom();
    
                Console.ReadLine();
            }
    
            static void HandleBoom(object sender, EventArgs e)
            {
                Console.WriteLine(sender.GetType());
            }
        }
    
        class Base
        {
            public event EventHandler Boom = null;
    
            public void TriggerBoom()
            {
                if(Boom != null)
                    Boom(this, EventArgs.Empty);
            }
        }
    
        class Derived : Base
        {
        }
