    public System.Windows.Forms.ListBox AddNewListBox()
    {
        return new System.Windows.Forms.ListBox() {
          Location = new Point(500, 74),
          parent   = this, // instead of this.Controls.Add(...)
        };
    }
    public System.Windows.Forms.TextBox AddNewTextBox()
    {
        return new System.Windows.Forms.TextBox() {
          Location = new Point(500, 180), 
          Text     = "item name",
          Parent   = this, 
        }; 
    }
    public System.Windows.Forms.Button AddNewButton() 
    {
        return new System.Windows.Forms.Button() {
          Location = new Point(500, 210),
          Text     = "Add item",  
          Parent   = this,  
        };
    }
