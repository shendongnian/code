    void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "SomeProperty":
                // Do something
                break;
        }
    }
