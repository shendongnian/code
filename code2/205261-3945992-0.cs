    MessageBoxResult result = MessageBox.Show("Foo Bar?", "Confirmation", MessageBoxButton.YesNoCancel);
    if (result == MessageBoxResult.Yes)
    {
        // yeah yeah yeah stuff
    }
    else if (result == MessageBoxResult.No)
    {
        // no no no stuff
    }
    else
    {
        // forget about it
    }
