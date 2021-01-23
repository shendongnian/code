    void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == GetProperty(() => Property1).Name)
        {
            // ...
        }
        else if (e.PropertyName == GetProperty(() => Property2).Name)
        {
            // ...
        }
    }
