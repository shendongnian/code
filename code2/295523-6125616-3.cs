    DateTime dt;
    string Temp1 = "Your Date";
    if (Temp1.LastIndexOf("GMT") > 0)
    {
        Temp1 = Temp1.Remove(Temp1.LastIndexOf("GMT"));
    }
    Temp1 = "Wed May 25 23:43:31 UTC+0900 2011";
    if (Temp1.LastIndexOf("UTC") > 0)
    {
         Temp1 = Temp1.Remove(Temp1.LastIndexOf("UTC"), 9);
         string[] split = Temp1.Split(' ');
         Temp1 = split[0] + " " + split[1] + " " + split[2] + " " + split[4] + " " + split[3];
    }
    if (DateTime.TryParse(Temp1, out dt))
    {
         // If it is a valid date
         string date = dt.ToShortDateString();
         string time = dt.ToShortTimeString();
    }
