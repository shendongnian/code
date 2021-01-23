     delegate void Invoker();
     private void setSpeed()
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Invoker(setSpeed));
                    return;
                }
     Simulation.SleepValue=Speed;
    }
      
