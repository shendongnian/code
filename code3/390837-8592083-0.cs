        timer.Interval = new TimeSpan(0, 0, 0, 1);
        timer.Tick += (sd, args) => // this is triggered when mouse stops.
        {
            if (a== b)
            {
               I do something here }; // it works until here.
            }
             timer2.Tick += (sd1, args1 ) => // // It doesnt allow me to put this timer here.
             {
                   I will do something here when mouse stops.
             }
         };
