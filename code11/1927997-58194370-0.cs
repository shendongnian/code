    public class SomeFoo
    {
        public int Identifier {get; set;}
        public someType someBar {get; set;}
    }
    public void DoStuff(IEnumerable<SomeFoo> foos, IEnumerable<int> ids)
    {
        //Algorithimically searching for a value in a Set is faster than in a list
        ISet<int> idsAsSet = ids as ISet<int> ?? new HashSet<int>(ids);
       
        var itemsWeWantToChange = foos.Where(f => idsAsSet.Contains(f.Identifier ));
        foreach(var item in itemsWeWantToChange)
        {
            item.someBar = ...
        }
    }
