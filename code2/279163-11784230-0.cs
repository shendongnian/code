    Public Class SortingAlgorithm
    {
        public int ID {get; set;}
        public string name {get; set;}
        public string address1 {get; set;}
        public string city {get; set;}
        public string state {get; set;}
        public int age {get; set;}
    }
    //declare a sorting algorithm list
    List<SortingAlgorithm> sortAlg = new List<SortingAlgorithm>();
    
    //Add multiple values to the list
    sortAlg.Add( new SortingAlgorithm() {ID = ID, name = name, address1 = address1, city = city, state = state, age = age});
    sortAlg.Add( new SortingAlgorithm() {ID = ID, name = name, address1 = address1, city = city, state = state, age = age});
    sortAlg.Add( new SortingAlgorithm() {ID = ID, name = name, address1 = address1, city = city, state = state, age = age});
    
    //query and order by the list
      var sortedlist = (from s in sortAlg
                        select new { s.ID, s.name, s.address1, s.city, s.state, s.age })
                                                         .OrderBy(r => r.ID)
                                                         .ThenBy(r=> r.name)
                                                         .ThenBy(r=> r.city)
                                                         .ThenBy(r=>r.state)
                                                         .ThenBy(r=>r.age);
