    bool handled = false;
    try
    {
        throw new Exception("Try Error!!!");
    }
    catch(Exception exp)
    {
        Console.WriteLine(exp.Message);
        Console.ReadLine();
        if (exp.Message == "Try Error!!!")
        {
            handled = true;
            return; // This isn't really necessary unless you have code below it you're not showing
        }
    }
    finally
    {
        if (!handled)
        {
            Console.WriteLine("Finally...");
            Console.ReadLine();
        }
    }
