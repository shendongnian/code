            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1); /* Try to use larger value suitable for you. */
            timer.Tick += (sd, args) => // This is triggered every 1sec.
            {
                Point currentpoint = /* Define current position of mouse here */ null;
                if (lastpoint == currentpoint)
                {
                    /* Do work if mouse stays at same */
                    /* { //EDIT*/
                    /* I haven't tried this, but it might work */
                    /* I'm assuming that you will always do new work when mouse stays */
                    DispatcherTimer timer2 = new System.Windows.Threading.DispatcherTimer(
                        TimeSpan.FromSeconds(1), /* Tick interval */
                        System.Windows.Threading.DispatcherPriority.Normal, /* Dispatcher priority */ 
                        (o, a) => /* This is called on every tick */
                        {
                            // Your logic goes here 
                            // Also terminate timer2 after work is done.
                            timer2.Stop();
                            timer2 = null;
                        },
                        Application.Current.Dispatcher /* Current dispatcher to run timer on */
                        );
                    timer2.Start(); /* Start Timer */
                    /* } //EDIT */
                }
                lastpoint = currentpoint;
            };
            timer.Start();
