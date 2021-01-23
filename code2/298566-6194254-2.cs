    private void DisableAllButtons(Panel parent)
    {
    
        foreach (var ctrl in parent.Children)
        {
    
            if (ctrl is Button)
            {
    
                ((Button)(ctrl)).IsEnabled = false;
  
            }
            else
            {
                 if (ctrl is Panel)
                 {
                      if (((Panel)ctrl).Children.Count > 0)
                      {
    
                          DisableAllButtons((Panel)ctrl);
    
                      }
                  }
    
             }
    
         }
    
      }
