        bool runfinallycode = true;
        try
        {
            throw new Exception("Try Error!!!");
        }
        catch(Exception exp)
        {
            Console.WriteLine(exp.Message);
            Console.ReadLine();
            if(exp.Message == "Try Error!!!")
                runfinallycode = false;
        }
        finally
        {
            if( runfinallycode )
            {
              Console.WriteLine("Finally...");
              Console.ReadLine();
            }
        }
