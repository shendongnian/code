    static readonly long variableZero=0; 
    const long constZero=0; 
    
    public static void Broken2( long ticks2) 
     { 
         long ticks = ticks2+variableZero; 
         if (ticks != (ticks - (ticks % 10000L))) 
         { 
             string.Format("Last Modified Date = '{0}'. Ticks = '{1}'. TicksCalc = '{2}'", 
                 "n/A", 
                 ticks, ticks - (ticks % 10000L)).Dump(); 
         } 
     }
