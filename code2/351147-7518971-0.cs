    To do so: 
    
       class Guy
        {
            public int age; public string name; string mood;
            public Guy( int age, string name,string mood ) {
                this.age = age;
                this.name = name;
                this.mood = mood;
            }
        
        }
        
        class Program
        {
            static void Main( string[] args ) {
               var GuyArray = new Guy[] { 
    new Guy(22,"John", "happy"),new Guy(25,"John", "sad"),new Guy(27,"John", "ok"),
    new Guy(29,"John", "happy"),new Guy(12,"Jack", "happy"),new Guy(32,"Jack", "happy"),
    new Guy(52,"Jack", "happy"),new Guy(100,"Abe", "ok")};
    
        
            var peepsSad = from f in GuyArray where f.mood=="sad" group f by f.name into g select new { name = g.Key, count = g.Count() };
    
     var peepsHappy = from f in GuyArray where f.mood=="happy" group f by f.name into g select new { name = g.Key, count = g.Count() };
    
     var peepsOk = from f in GuyArray where f.mood=="ok" group f by f.name into g select new { name = g.Key, count = g.Count() };
        
        
                foreach ( var record in peepsSad ) {
                    Console.WriteLine( record.name + " : " + record.count );
                }
    
      foreach ( var record in peepsHappy ) {
                    Console.WriteLine( record.name + " : " + record.count );
                }
    
      foreach ( var record in peepsOk ) {
                    Console.WriteLine( record.name + " : " + record.count );
                }
        
            }
        }
