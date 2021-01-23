     const string TEXTBOX = "textbox";
        const string CHECKBOX = "checkbox";
        
        //assuming your result set is placed in a data table or dictionary we can enumerate through //the result set and based on the text comparison add a check box or textbox.  
        
        Panel panel = new Panel();
        
        DataTable dataTable = getResultSet();
        foreach(DataRow row in dataTable.Rows)
        {
            string comparison = row["<columnNameContaining yuur "TextBox" or "CheckBox text>"].value;
            switch(comparison)
            {
                case TEXTBOX:
                    textBox = new TextBox();
                    panel.Controls.Add(textBox);
                    break;
                case CHECKBOX;
                    CheckBox checkBox = new checkBox();
                    panel.Controls.Add(checkBox);
                    break;
            }
         }
