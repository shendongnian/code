    int count =0;
    private void FindControl(Control Page)
     {
  
     foreach (Control ctrl in Page.Controls)
     {
          if (ctrl is ListBox)
          {
             count++;
          }
          else 
          {
              if (ctrl.Controls.Count > 0)
              {
                   FindControl(ctrl);
              }
          }
     }
    }
