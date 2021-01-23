    private void SomeButton_Click(...)
    {
        using (FileStream fs = ...)
        {
            fs.Write(some form data);
            fs.Write(some more form data);
        }
    
        DoMoreBusinessLogicStuff();
        ...
        // lots more stuff
        ...
    }
