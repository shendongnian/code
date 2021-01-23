    using System;
    
    namespace RandomNumbers
    {
        class Program
        {
            static void Main( string[] args )
            {
                const int screenLeftX = 0;
                const int screenRightX = 1024;
                const int cowMovementStep = 5;
    
                var rnd = new Random();
    
                var cowLocation = rnd.Next( screenLeftX, screenRightX );
    
                // Will generate 100 different locations.
                // In your game you will generate a new location when the timer_tick event is raised.
    
                for( var iter = 0; iter < 100; iter++ )
                {
                    cowLocation = cowLocation + rnd.Next( -cowMovementStep, cowMovementStep );
                    Console.WriteLine( "New location:{0}", cowLocation );
                }
            }
        }
    }
