    class Room
    {
        public int Area;
    }
    
    class Pair
    {
        public Room One;
        public Room Two;
    }
    
    // In some class...
    public List<Pair> pairs = new List<Pair>();
    
    // (...) in some method
    // Retrieve the members "One" that are larger
    var query_for_one = from p in pairs
                                    where p.One.Area > 100
                                    select p.One;
    
    // Retrieve the members "Two" that are larger
    var query_for_two = from p in pairs
                        where p.Two.Area > 100
                        select p.Two;
    
    // Return the union of both queries:
    var query = query_for_one.Union(query_for_two);
