    public TimerMode f2 = new TimerMode();
    public void DoActions(string Cmd)
    {
      switch(Cmd){    
      case"Open":          
          f2.show()
          break;
      case"Closing":
           f2.Close();
           break;
      }
    }
