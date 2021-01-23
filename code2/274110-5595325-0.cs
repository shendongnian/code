    ...
    }
    catch (Exception ex)
    {
        if (ex.InnerException != null)
            Console.WriteLine(ex.InnerException.ToString());
        else
            Console.WriteLine("No Inner Exception");
    }
