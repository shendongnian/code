      static void Main(string[] args)
      {
          // Collection of movies (empty) 
          List<movie> myMovie = new List<movie>();
          // Let's add some movies into the collection
          myMovie.Add(new movie() {name = "Harry Potter"});
          myMovie.Add(new movie() {name = "Lord of The Rings"});
          myMovie.Add(new movie() {name = "Star Wars"});
          // Time to inspect the collection 
          Console.WriteLine($"We have {myMovie.Count} movies in the collection");
          Console.WriteLine("They are:"); 
          // myMovie[i] returns i-th movie within the collection 
          for (int i = 0; i < myMovie.Count; ++i)  
            Console.WriteLine($"  {i + 1}. {myMovie[i].name}");
      } 
