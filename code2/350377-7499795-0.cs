    threadfunction()
    {
     myControl.Update(result);
    }
    
    class TheControl
    {
     public void Update(object result)
     {
      if (this.InvokeRequired)
       this.Invoke(new Action<object>(Update), result);
      else
      {
       // actual implementation
      }
     }
    }
