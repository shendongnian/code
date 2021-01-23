    var result = from p in dataSource 
                 group p by p.City into cities 
                 select new { Property1 = cities.Key, Property 2= cities.Average(p => p.Age) }; 
    
    dt.Columns.Add("Property1"); 
    dt.Columns.Add("Property2"); 
    foreach (var item in result) 
    {   
        dt.Rows.Add(item.Property1,item.Property2);                 
    } 
