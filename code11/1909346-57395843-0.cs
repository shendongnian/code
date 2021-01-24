    DateTime start = new DateTime(...);
    DateTime end = new DateTime(...);
    int interval = 30;
    DateTime current = start;
    
    while ((DateTime.Compare(current, end) < 0) {
      deliveryTimeList.Add(current.ToString("HH:mm"));
      current.AddMinutes(interval);
    }
