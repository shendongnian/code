     System.Timers.Timer[] myTimerCoral=new System.Timers.Timer[10];
            private void Form1_Load(object sender, EventArgs e)
            {
                for (int n = 0; n <= 10; n++)
                {
                    myTimerCoral[0]= new System.Timers.Timer();
                    myTimerCoral[0].Elapsed += new ElapsedEventHandler(OnTimedEventCoral);
                    myTimerCoral[0].Interval = 1000;
                    myTimerCoral[0].Start();
    
                    myTimerCoral[1] = new System.Timers.Timer();
                    myTimerCoral[1].Elapsed += new ElapsedEventHandler(OnTimedEventAliceBlue);
                    myTimerCoral[1].Interval = 1000;
                    myTimerCoral[1].Start();
    
                }
               // this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            }
            private void OnTimedEventCoral(object source, ElapsedEventArgs e)
            {
                this.BackColor = Color.Black;
                myTimerCoral[1].Stop();
            }
            private  void OnTimedEventAliceBlue(object source, ElapsedEventArgs e)
            {
                this.BackColor = Color.White;
                myTimerCoral[0].Stop();
            }
