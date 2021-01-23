    public string GetValue(Control ctl) {
      if (ctl != null) {
        //Textbox
        if (ctl is TextBox) return ctl.Text;
        //Combobox
        if (ctl is ComboBox) {
          ComboBox cb = ctl as ComboBox;
          return cb.SelectedText;
        }
        //...
      }
      //Default Value (You can also throw an exception
      return "";
    }
