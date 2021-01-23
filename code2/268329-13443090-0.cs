    // ---- Original WinForm code ----
    delegate void SetIndicatorCallback(bool bVal);
    
    private void SetIndicator(bool bVal)
    {
       if (this._connection.InvokeRequired)
       {
          SetIndicatorCallback d = new SetIndicatorCallback(SetIndicator);
          this.Invoke(d, new object[] { bVal });
       }
       else
       {
          if (bVal)
          {
               // Change the control's color, or whatever action is required.
          }
    
       }
    }
    
    // ---- WPF ----
    
    // Still using a delegate 
    delegate void SetIndicatorCallback(bool bVal);
        
                
    private void SetIndicator(bool bVal)
        {
            if (this._connection.Dispatcher.CheckAccess())
            {
              if (bVal)
              {
                    // Change the control' color, or whatever action is needed.
              }
            }
            else
            { 
               SetIndicatorCallback d = new SetIndicatorCallback(SetIndicator);
               this.Dispatcher.BeginInvoke(d, new object[] { bVal });
            }
         }
