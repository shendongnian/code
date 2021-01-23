    public void Timer1_Event(object source, ElapsedEventArgs e)
    {
      if(DateTime.Now.Substract(incidentreportedtime).TotalMinutes == 30)
      {
        //Send mail to user
      }
    }
