      public void AddItems (ComboBox cboBox, Type enumType)
      {
         cboBox.Items.AddRange(Enum.GetValues (enumType).Cast<object> ().ToArray ());
      }
      enum Options
      {
         Left, Right, Center
      }
