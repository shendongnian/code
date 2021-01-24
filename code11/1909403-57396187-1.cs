    List<Person> People = ...
    
    var result = People
      .GroupBy(person => new {
         person.Name,
         person.Age 
       })
      .Select(chunk => new Person() {
         Name      = chunk.Key.Name,
         Age       = chunk.Key.Age,
         Interests = chunk
           .SelectMany(item => item.Interests)
           .Distinct()
           .ToList()
       })
      .ToList(); // if we want List<People> 
