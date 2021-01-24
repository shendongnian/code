    public IEnumerable<A> GetDetails(int ID)
    {
       var listA = new List<A>
       {
          new A(){ ID = 1, Name = 2 },
          new A(){ ID = 3, Name = 4 },
          new A(){ ID = 5, Name = 6 },
       };
    
       var listB = new List<B>
       {
           new B(){ X = 1, name = 0 },
           new B(){ X = 3, name = 1 }
       };
    
       return listA.Join(listB, k => k.ID, k => k.ID, (item, item2) =>
       {
           item.Name = item2.name;
           return item;
       }).Where(w => w.ID == ID);
    }
