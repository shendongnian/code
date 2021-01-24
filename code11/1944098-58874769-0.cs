    string[] UserActivity = File.ReadAllLines(@"useractivityfile");
    string[] UserDateTime = File.ReadAllLines(@"userdatetimesfile");
    DateTime greaterthanthis = new DateTime(2019, 1, 12);
    for (int i = 0; i < UserActivity.Length; i++)
    {
      if (DateTime.ParseExact(UserDateTime[i], "dd/MM/yyyy", CultureInfo.InvariantCulture) > greaterthanthis)
      {
        Console.WriteLine(UserDateTime[i]);
        //Also want to link the useractivity so Console.WriteLine(UserDT[i] + UserDT[i])
      }
    }
