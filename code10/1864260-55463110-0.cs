        void Timer_Tick(object sender, object e)
         {
            int BaseINMill = basetime * 1000;
            //total of milliseconds left
            basetimeMILL.Text = BaseINMill.ToString() ;
            //Display the total Milliseconds elapsed
            ConsolePost.Text = VerifyMill.ElapsedMilliseconds.ToString();
            
            if( CorrectionWatch.ElapsedMilliseconds >= 2000)
            {
                PreCorrBaseTime = PreCorrBaseTime - 2;
                //Display the Correction timer Milliseconds elapsed
                Correctiontest.Text = CorrectionWatch.ElapsedMilliseconds.ToString();
                CorrectionWatch.Restart();
                //Show the total time between seconds changing on screen
                ConsoleOutputPre.Text = stopwatch.ElapsedMilliseconds.ToString();
                basetime = PreCorrBaseTime;
                txt.Text = string.Format("{0:00}:{1:00}:{2:00}", basetime / 3600, (basetime / 60) % 60, basetime % 60);
                if (basetime == 0)
                {
                    timer.Stop();
                    Timer_Start.IsEnabled = Timer_Pause.IsEnabled = Timer_Restart.IsEnabled = true;
                    VerifyMill.Stop();
                }
                stopwatch = Stopwatch.StartNew();
            }
            else {
                if (stopwatch.ElapsedMilliseconds >= 975 && stopwatch.ElapsedMilliseconds <=1025 )
                {
                    //Show the total time between seconds changing on screen
                    ConsoleOutputPre.Text = stopwatch.ElapsedMilliseconds.ToString();
                    basetime = basetime - 1;
                    txt.Text = string.Format("{0:00}:{1:00}:{2:00}", basetime / 3600, (basetime / 60) % 60, basetime % 60);
                    if (basetime == 0)
                    {
                        timer.Stop();
                        Timer_Start.IsEnabled = Timer_Pause.IsEnabled = Timer_Restart.IsEnabled = true;
                        VerifyMill.Stop();
                    }
                    stopwatch = Stopwatch.StartNew();
                }
                if (stopwatch.ElapsedMilliseconds >= 1026 && stopwatch.ElapsedMilliseconds <= 2000)
                {
                    //Show the total time between seconds changing on screen
                    ConsoleOutputPre.Text = stopwatch.ElapsedMilliseconds.ToString();
                    basetime = basetime - 1;
                    txt.Text = string.Format("{0:00}:{1:00}:{2:00}", basetime / 3600, (basetime / 60) % 60, basetime % 60);
                    if (basetime == 0)
                    {
                        timer.Stop();
                        Timer_Start.IsEnabled = Timer_Pause.IsEnabled = Timer_Restart.IsEnabled = true;
                        VerifyMill.Stop();
                    }
                    stopwatch = Stopwatch.StartNew();
                }
                if (stopwatch.ElapsedMilliseconds > 2000)
                {
                    ErrorPrompt();
                    VerifyMill.Stop();
                }
            }
        }
