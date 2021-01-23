    void Method()
    {
        do
        {
            try
            {
                DoStuff();
                return;
            }
            catch (Exception e)
            {
                // Do Something about exception.
            }
        }
        while (true);
    }
