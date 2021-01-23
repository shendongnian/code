    private CheckBox DoSomethingWith(CheckBox checkBox, Point location, string text)
    {
        checkBox.AutoSize = true; 
        checkBox.Checked = false; 
        checkBox.CheckState = CheckState.Unchecked; 
        checkBox.Location = location;
        checkBox.Text = text; 
        checkBox.UseVisualStyleBackColor = true;
        return checkBox;    
    }
