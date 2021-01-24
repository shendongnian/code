    private void Method1()
    {
        try
        {
            throw new Exception("Inside Method1"); // line 42
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception " + ex);
            throw; // line 47
        }
    }
