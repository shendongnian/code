    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.NetworkInformation;
    namespace ConsoleApplication6
    {
    
        
        class Program
        {
            private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
            {
               
                if (e.IsAvailable)
                    Console.WriteLine("Network connected!");
                else
                    Console.WriteLine("Network dis connected!");
            }
            public void Form1()
            {
               
                NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
            }
    
            static void Main(string[] args)
            {
                Program p = new Program();
               
                p.Form1();
    
                Console.ReadLine();
    
            }
        }
    }
