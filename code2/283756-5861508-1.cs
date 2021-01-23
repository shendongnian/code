    private void AddChangedHandlers(ControlCollection controls)
       {
          foreach (Control ctrl in controls)
          {
             if (ctrl is TextBox)
             {
                ((TextBox)ctrl).TextChanged += new EventHandler(this.HandleRowChanged);
             }
             else if (ctrl is CheckBox)
             {
                ((CheckBox)ctrl).CheckedChanged += new EventHandler(this.HandleRowChanged);
             }
             else if (ctrl is DropDownList)
             {
                ((DropDownList)ctrl).SelectedIndexChanged += new EventHandler(this.HandleRowChanged);
             }
          }
       }
