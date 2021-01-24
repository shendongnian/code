    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
      {
         lock (this)
            {
             if (Math.Abs(Rate - MAX) < double.Epsilon){
                 //something you want to do
                   ...
                }
            }
      }
