    result = Products.GroupBy(x => x.Price)
                      .Select(g => new { g.Name, Count = g.Count() 
                              })
                      .Orderby(s.Count)
                      .Select(x.Name, x.Count).FirstOrDefault();    
    if(result.Count == 1){
      return result;
    }
    else{
      return null;
    }
