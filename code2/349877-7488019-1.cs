    var sumList = methodList.Select( x=> 
        {
            var parts = x.Split(';');
            return new
            {
                Method = parts [0],
                Cost = Convert.ToInt32(parts[1])
            };
        })
        .GroupBy( x=> x.Method)
        .Select( g=> new { Method = g.Key, Sum = g.Sum( x=> x.Cost) })
        .ToList();
    foreach(var item in sumList)
        Console.WriteLine("Total for {0}:{1}", item.Method, item.Sum);
