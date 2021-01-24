        string dateTimeStr = "2019-04-35";
        DateTime dateTime;
        if (DateTime.TryParse(dateTimeStr, out dateTime))
        {
            Console.WriteLine(dateTime);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
