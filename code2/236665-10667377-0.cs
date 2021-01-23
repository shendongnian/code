     //Where "this" is Page.
     ClearInput(this);
     private void ClearInput(Control parent)
     {
         foreach (Control c in parent.Controls)
         {
              if (c.Controls.Count > 0)
                    ClearInput(c);
              else
              {
                   if (c is TextBox)
                      (c as TextBox).Text = "";
                   if (c is CheckBox)
                      (c as CheckBox).Checked = false;
                    if (c is DropDownList)
                       (c as DropDownList).SelectedIndex = 1;
               }
           }
       }
