    var timeLimit = new TimeSpan(0, 0, 15); // 15 sec
    var dateStart = DateTime.Now;
    var inputs = new List<string>();
    while ( DateTime.Now - dateStart <= timeLimit )
      inputs.Add(Console.ReadLine());
