    bool Enable()
    {
         var result = StatusChecks().All( b => b );
         if ( !result )
         {
             Trace.WriteLine("Error");                       
         }
         return result;
    }
    
