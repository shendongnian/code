    public static int DisplayCalender(int days, int start) //Display Function//
    {
	    int startDay = start == 7 ? 0 : start;
        Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
        for (int i = 0; i < startDay; i++)
            Console.Write("\t");
        for (int i = 1; i <= days; i++)
        {
            if (startDay > 6)
            {
                startDay = 0;
                Console.WriteLine();
            }
            Console.Write(i + "\t");
            startDay++;
        }
        return startDay;
    }
