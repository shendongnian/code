    private void Recursive(TableLayoutPanel tableCriterias)
    {
        foreach (var control in tableCriterias.Controls)
        {
            var textBox = control as TextBox;
            if (textBox != null)
                textBox.KeyPress += new KeyPressEventHandler(this.ApplyFiltersOnEnterKey);
            else if(control is TableLayoutPanel)
                Recursive(control as TableLayoutPanel);
        } 
    }
