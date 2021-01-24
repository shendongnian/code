      using System.Linq;
      ... 
      int distributeVal = 7;
      List<int> validationList = new List<int>() { 2, 2, 2, 3 };
      ...
      // validationList = if you want to "update" validationList
      var result = validationList
        .TakeWhile(_ => distributeVal > 0)   // Keep on while we have a value to distribute
        .Select(item => {                    // Distribution
          int newItem = item > distributeVal // two cases: 
            ? distributeVal                  //   we can distribute partialy  
            : item;                          //   or take the entire item
          distributeVal -= newItem;          // newItem has been distributed  
          return newItem;
        })
        .ToList();
     Console.Write(string.Join(", ", result));
