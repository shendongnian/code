    ....
    DateTime Ende = new DateTime();
    if(DateTime.Now.ToString("tt") == "AM")
    {
      Ende = new DateTime(Start.Year, Start.Month, Start.Day, 12, 20, 0);
    }
    else
    {
      Ende = new DateTime(Start.Year, Start.Month, Start.Day + 1, 0, 20, 0);
    }
