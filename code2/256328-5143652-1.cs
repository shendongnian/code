    public static void CurrentlyOnUiThread<T>(T control)
    { 
       if(T is System.Windows.Forms.Control)
       {
          System.Windows.Forms.Control c = control as System.Windows.Forms.Control;
          return !c.InvokeRequired;
       }
       // else do WPF check
    }
