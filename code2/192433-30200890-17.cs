    void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Foo":
            case "Bar":
            case "Baz":
                FooBarBazCommand.Invalidate();
                break;
            ....               
        }
    }
