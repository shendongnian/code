    public Control FormAsControl()
    {
        using (Form form = new Foo())
        {
            // Set properties
            return form;
        }
    }
