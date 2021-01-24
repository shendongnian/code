    public static int DisplayCalender(int days, int start) //Display Function//
    {
        int startDay = start;
        Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
        if (start < 7)
        {
            for (int i = 0; i < start; i++)
            {
                Console.Write("\t");
            }
        }
        for (int i = 1; i <= days; i++)
        {
            if (startDay > 6)
            {
                startDay = 0;
                if (i != 1 )
                {
                    Console.WriteLine();
                }
            }
            Console.Write(i + "\t");
            startDay++;
        }
        return startDay;
    }
