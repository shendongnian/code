    var nextDateStartDateTime = DateTime.Now.AddDays(1).Subtract(DateTime.Now.TimeOfDay);
    double millisecondsToWait = (nextDateStartDateTime - DateTime.Now).TotalMilliseconds;
                
    System.Threading.Timer timer = new Timer(
        (o) => { Debug.WriteLine("New day comming on"); },
        null,
        0,
        (uint)millisecondsToWait);
