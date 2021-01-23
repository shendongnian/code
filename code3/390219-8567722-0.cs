    var a = ReceivedPayments.Select(c=>c.Id);
    int interval = 50;
    var ids = new List<int>();
    int min = a.Min();
    int max = a.Max();
    for (int i = min; i < max; i++)
    {
        if((i % interval) == 0)
        {
            ids.Add(i);
        } 
    }
   
    var b = ReceivedPayments.Where(c=>ids.Contains(c.Id));
    
