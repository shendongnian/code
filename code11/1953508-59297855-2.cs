    protected override void OnAppearing()
    {
        base.OnAppearing();
                
        if (selection.IsFocused)
            selection.Unfocus();
        else
            selection.Focus();
               
    }
