    void MyServiceMethod(object parameters)
    {
        // Assuming you have some method to validate your parameters
        if (!Validate(parameters))
        {
            throw new Exception("My error string");
        }
    }
