    private void FocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var flag = e.NewValue as bool?;
        if (flag != true)
        {
            Canvas.Focus();
        }
    }
