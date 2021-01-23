    public void DoStuff(IEnumerable<string> key, int iClassId){
        foreach (var classEntry in
                 from c in mappings.Where(i=>key.Contains(i.Key))
                 where c.StartsWith(iClassId + "(")
                 select c)
        {
            DoStuffWithEntry(classEntry);
        }
    }
