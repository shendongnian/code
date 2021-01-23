    foreach (Control c in hashtable.Values)
    {
        if(c is RadioButton)
        {
            string name = x.Name;
            bool isChecked = (c as RadioButton).Checked;
        }
    }
