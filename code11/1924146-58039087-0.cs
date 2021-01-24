    static string Invoker()
    {
        string result;
        using (Animal a = new Animal())
        {
            result = a.Greeting();
            //a return here is like a goto end;
        }
        //end:
        return result;
    }
