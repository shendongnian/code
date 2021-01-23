    foreach (Control ctrl in Controls)
    {
        if (ctrl is MyThemableButton)
            ((MyThemableButton)ctrl).SetTheme(newTheme);
        else if (ctrl is MyThemableTextBox)
            ((MyThemableTextBox)ctrl).SetTheme(newTheme);
        else if (ctrl is MyThemableGridView)
            ((MyThemableGridView)ctrl).SetTheme(newTheme);
        else ....
    }
