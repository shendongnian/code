    List<Person> People = ...
    
    var result = People
      .GroupBy(person => new {
         person.Name,
         person.Age 
       })
      .Select(chunk => new Person() {
         Name      = chunk.Name,
         Age       = chunk.Age,
         Interests = chunk
           .SelectMany(item => item.Interests)
           .Distinct()
           .ToList()
       })
      .ToList(); // if we want List<People> 
