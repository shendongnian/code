    static void Main(string[] args)
    {
        bool keepRunning = true;
        int x = 0;
        while (keepRunning)
        {
            //at some point, flip keepRunning to fall out of the while loop
            if (moon.Color == Blue)
               keepRunning = false;
            if (x > 0) //or some other condition
                return;
        }
       //naturally will fall out of the Main() and terminate the program
    }
