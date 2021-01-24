    public IEnumerable<keyart1> Get([FromUri] string[] keyword1)
    {
        List<keyart1> keylist;
        List<IEnumerable<keyart1>> ll;
        using (dbEntities5 entities = new dbEntities5())
    
        {
            ll = new List<IEnumerable<keyart1>>();
            foreach (var item in keyword1)
            {
                keylist = entities.keyart1.Where(e => e.keyword != item).ToList();
                var result = keylist.Distinct(new ItemEqualityComparer());
                ll.Add(result);
            }
            var intersection = ll.Aggregate((p, n) => p.Intersect(n).ToList());
           return intersection; 
        }
    }
