    Type mytype=typeof(TextBox);
    foreach(PropertyInfo myinfo in mytype.GetProperties())
    {
        ListBox1.Items.Add(myinfo.Name);
        if(myinfo.Name == "Parent")
        {    
            PropertyInfo subProperty = typeof(Control).GetProperty("Name")
            if(subProperty != null)
                // Do some more stuff here
        }
    }
