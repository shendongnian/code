    private void DisableAutoSize()
    {
      foreach (Control control in Controls)
      {
        Label label = control as Label;
        if (label == null || control.Name.Contains("Label"))
        {
          continue;
        }
         
       label.AutoSize = false;   
      }
    }
