    private void FindControls(Control Page)
    {
         foreach (Control ctrl in this.Controls)
         {
              if (ctrl is CheckBox)
              {
                  if (cb! = null & & cb.Checked)
                  {                   
                       cb.Checked = false;                
                  }
              }
              else 
              {
                  if (ctrl.Controls.Count > 0)
                  {
                       FindControls(ctrl);
                  }
              }
         }
    }
