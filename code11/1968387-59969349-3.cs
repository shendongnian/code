     // Orders to be tested 
     IEnumerable<string> firstNameUnderTest = ...
     IEnumerable<string> lastNameUnderTest = ...
     var counterExamples = names
       .Zip(firstNameUnderTest, (name, fn) => new {name, fn})
       .Zip(lastNameUnderTest, (item, ln) => new {
          expectedFirst = item.name.first,
          expectedLast  = item.name.last,
          actualFirst   = item.fn,
          actualLast    = ln     
        })
       .Where(item => item.expectedFirst != item.actualFirst ||
                      item.expectedLast != item.actualLast)
       .Select(item => $"Expected: {item.expectedFirst}, {item.expectedLast}; " +
                       $"Actual: {item.actualFirst}, {item.actualLast}")
       .ToArray();
