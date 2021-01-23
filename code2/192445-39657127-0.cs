    void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(ClassName.Property1):
                ...
            case nameof(ClassName.Property2):
                ...
    
            ....               
        }
    }
