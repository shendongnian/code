    void Validate(Expression<Func<bool>> validation)
    {
        if (!Lambda.Compile(validation)())
        {
            string message = "..." //parse lambda expression here.
            //see: http://msdn.microsoft.com/en-us/library/bb397951.aspx
            throw new Exception(message);
        }
    }
    try
    {
       Validate(() => 1 > 2);
    }
    catch (Exception e)
    {
        Console.Write(e.Message)// This is where I would output the error to the user
    }
