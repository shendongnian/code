        foreach (Control c in this.Controls)
        {
            if (c is CheckBox)
            {
                if (((CheckBox)c).IsChecked == true)
                    // do something
            }
        }
