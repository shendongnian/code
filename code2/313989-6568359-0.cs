    public IEnumerable MethodAmk(){
              var query = from row in _Hdt.AsEnumerable()         
                          group row by row.Field<int>("DATE") into grp         
                          orderby grp.Key         
                          select new {         
                                DATE = grp.Key,         
                                Sum = grp.Sum(r => r.Field<decimal>("KW"))         
                };          
              foreach (var grp in query)         
                    {         
                     Console.WriteLine("{0}\t{1}", grp.Id, grp.Sum);         
                   } 
              return query;
    }
