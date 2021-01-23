    public void DoStuff(IEnumerable<string> key, int iClassId)
    {
        mappings.Where(i=>key.Contains(i.Key)).ToList().ForEach(obj=>
        {
            foreach (var classEntry in
                 from c in obj.Value
                 where c.StartsWith(iClassId + "(")
                 select c)
            {
                DoStuffWithEntry(classEntry);
            }
    }
