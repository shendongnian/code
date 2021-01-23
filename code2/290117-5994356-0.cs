    static int Main(string[] args)
    {
        try
        {
            //do some stuff
            return 0; //everything is good
        }
        catch //you will want more specific error-handling, catch-all is for example only
        {
            return 1; //something blew up!
        }
    }
