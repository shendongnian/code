    class IProcess
    {
      public delegate void Timer_Elapsed_Handler (IProcess process, ElapsedEventArgs e);
      public event Timer_Elapsed_Handler Timer_Elapsed;
        
      public void IProcess_Timer_Elapsed (object sender, ElapsedEventArgs e)
      {
        if (Timer_Elapsed != null) Timer_Elapsed (this, e);
      }
    }
