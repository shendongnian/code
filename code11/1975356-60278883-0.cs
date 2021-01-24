    //Member variable
    var textBox = new TextBox();
    public void CreateTextBox(int length)
    {
        for (int index = 0; index < length; index++)
        {
                textBox = new TextBox();
                textBox.ID = "PFtxtname" + "_" + index;
                textBox.CssClass = "yourCSSClass";
                textBox.ClientIDMode = ClientIDMode.Static;
                this.Controls.Add(textBox);
         }
    }
