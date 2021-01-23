    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace BlogSamples
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Assume that Car is IDisposible.
                using (Car myCar = new Car(1))
                {
                    myCar.Run();
                }
            }
        }
    }
