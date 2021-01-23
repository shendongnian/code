       TextBox txtUsername = new TextBox();
       txtUsername.Name = "txtUsername ";
    
    
    
      void SetEnable(string str, bool enable)
      {
        this.Controls.Item("txt" + str).Enabled = enabled;
      }
