    var people = from p in db.Persons select new {p.Id, p.LastName, p.FirstName, p.Email};
    var tags = queryTags.AsCached("Persons", new QueryCachedOptions () {
      OnInvalidate = (sender, args) => {
        Console.WriteLine("Notification called !");
      }
     });
    // Again, the underlying SqlCommand must actually be executed. Iterate the query
    foreach (p in people) {
     ....
    }
  
