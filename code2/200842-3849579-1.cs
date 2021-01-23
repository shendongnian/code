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
                //Declare myCar object with FullName of the type as seen in IL.
                BlogSamples.Car myCar;
    
                //Instantiate the object by calling the constructor, matching the flow of IL.
                myCar = new Car(1);
    
                try
                {
                    myCar.Run();
                }
                finally
                {
                    if(myCar != null)
                        myCar.Dispose();
                }
            }
        }
    }
