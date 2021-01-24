    public string SelectedText 
    {
        get 
        {
            if (DropDownStyle == ComboBoxStyle.DropDownList) 
                return "";
            return Text.Substring(SelectionStart, SelectionLength);
        }
        {
            // see link
        }
    }
