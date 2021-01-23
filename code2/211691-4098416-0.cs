    // create a wrapper class that can accomodate either an Alpha or a Bravo
    class ABItem { 
       public Object Instance   { get; private set; }
       public int Id            { get; private set; }
       public ABItem( Alpha a ) { Instance = a; Id = a.Id; }
       public ABItem( Bravo b ) { Instance = b; Id = b.Id; }
    }
    // comparer that compares Alphas and Bravos by id
    class ABItemComparer : IComparer {
       public int Compare( object a, object b ) { 
           return GetId(a).Compare(GetId(b));
       }
       private int GetId( object x ) {
           if( x is Alpha ) return ((Alpha)x).Id;
           if( x is Bravo ) return ((Bravo)x).Id;
           throw new InvalidArgumentException();
       }
    }
    // create a comparer based on comparing the ID's of ABItems
    var comparer = new ABComparer(); 
    var hashAlphas = 
        new HashSet<ABItem>(myAlphaItems.Select(x => new ABItem(x)),comparer);
   
    var hashBravos = 
        new HashSet<ABItem>(myBravoItems.Select(x => new ABItem(x)),comparer);
    // items with common IDs in Alpha and Bravo sets:
    var hashCommon = new HashSet<Alpha>(hashAlphas).IntersectWith( hashSetBravo );
    hashSetAlpha.ExceptWith( hashSetCommon );  // items only in Alpha
    hashSetBravo.ExceptWith( hashSetCommon );  // items only in Bravo
