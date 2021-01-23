    private void timer1_Tick(object sender, EventArgs e)
        {
          DateTime Time = DateTime.Now;
              int minutes = Time.Minute;
                if (minutes == 00)  //FIRE ON THE HOUR
                    { DO THIS  }
                if (minutes == 15)  //FIRE ON 1/4 HOUR
                    {  DO THIS }
                if (minutes == 30)  //FIRE ON 1/2 HOUR
                    { DO THIS }
                if (minutes == 45)  //FIRE ON 3/4 HOUR
                    { DO THIS }
        }
