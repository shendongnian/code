        string dateTimeStr = "2019-04-35";
        DateTime dateTime;
        if (DateTime.TryParse(dateTimeStr, out dateTime2))
        {
            Console.WriteLine(dateTime);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
