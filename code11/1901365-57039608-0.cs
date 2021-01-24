    var filtered = dogList
      .GroupBy((item => new { 
         item.Name, 
         item.ImportDate.Date 
       })
      .Select(chunk => new Dog() { //TODO: Use the right syntax here
         Name       = chunk.Key.Name,
         ImportDate = chunk.Max(item => item.ImportDate), 
         Price      = chunk.Where(item => item.Price.HasValue).Max(item => item.Price.Value)
       })
      .ToList();
