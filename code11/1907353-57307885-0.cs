    using System;
    using System.Collections.Generic;
    
    namespace Airport
    {
        public class Airport
        {
            private readonly List<string>  planes;
            public Airport()
            {
                planes = new List<string>();
            }
    
            public void Land(string plane)
            {
                planes.Add(plane);
            }
        }
    }
