       public class Day : TimeMulti
        {
    		// Properties 
            public float Mult1 { get; set; }
    		
    		// Constructor 
            public Day(): base(1) { }
    
            // This method to map the values to the properties 
            protected override float SetMult(int multNumber, float multValue)
            {
                switch (multNumber)
                {
                    case 1:
                        Mult1 = multValue;
                        break;
                }
    
                return multValue;
            }   
    
        }
