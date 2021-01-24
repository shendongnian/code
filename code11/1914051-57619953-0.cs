    foreach (Control con in Controls)
    {
        if (con is CheckBox checkBox)
        {
           checkBox.IsChecked ^= true;
        }
    }
