     using (EtradeContext context = new EtradeContext())
        {
    
            var result = context.Students
                .Where(x => x.name == "emre")
                .Select(s => new
                {
                    name = s.name
                    ,
                    price = s.price
                }).ToList();
    
            return result;
        }
