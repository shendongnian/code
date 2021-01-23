    public static class CheckboxExtensions
    {
         public static void ToggleChecked(this CheckBox some) 
         {
               if(some != null) 
               {
                      if(some.Checked)
                      {
                            some.Checked = false;
                      }
                      else
                      {
                            some.Checked = true;
                      }
               }
        }
    }
