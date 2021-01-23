    string a = "05:21:50";
    DateTime alarm = new DateTime();
    alarm = DateTime.ParseExact(a, "H:m:s", null);
    Console.WriteLine(alarm.ToString("H:m:s"));
    Console.WriteLine(alarm.Hour);
    Console.WriteLine(alarm.Minute);
    Console.WriteLine(alarm.Second);
