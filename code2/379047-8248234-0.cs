    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace setCC
    {
        class Program
        {
            static int Main( string[] args )
            {
                if ( args.Length == 0 ) throw new ArgumentException( "Required Argument is missing" ) ;
                int  cc      ;
                bool isValid = int.TryParse( args[0] , out cc ) ;
                if ( !isValid ) throw new ArgumentException( "Required parameter is not a valid number") ;
                return cc ;
            }
        }
    }
