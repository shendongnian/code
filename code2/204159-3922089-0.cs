    private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var form = (RegCardSearchForm)d;
        if (e.OldValue != null)
            ((RegistrationCardSearch)e.OldValue).PropertyChanged -= form.RequestObject_PropertyChanged;
        if (e.NewValue != null)
            ((RegistrationCardSearch)e.NewValue).PropertyChanged += form.RequestObject_PropertyChanged;
    }
    private void RequestObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        MessageBox.Show("Property " + e.PropertyName + " changed!");
    }
