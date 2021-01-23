    void Main()
    {
        List<BooClass> booList = new List<BooClass> { 
                            new BooClass { field3 = DateTime.MaxValue}, 
                            new BooClass { field3 = DateTime.Now },
                            new BooClass { field3 = DateTime.MinValue }};
        var pred = GetPredicate(booList);
        var result = booList.Find(pred);
    }
    
    public Predicate<BooClass> GetPredicate(List<BooClass> boos)
    {
        var minDate = boos.Min(boo => boo.field3);	 
        return bc => bc.field3 == minDate;
    }
