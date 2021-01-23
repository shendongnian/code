     public Control DisableDropDowns(Control root)
     {             
         foreach (Control ctrl in root.Controls)
         {
             if (ctrl  is DropDownList)
                 ((DropDownList)ctrl).Enabled = false;
             DisableDropDowns(ctrl);
         }
     }
