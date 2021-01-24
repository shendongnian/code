      using System.IO;
      using System.Linq;
      ...
      File.WriteAllLines(@"c:\myFile.txt", cars
        .Select(car => string.Join(",", properties
           .Select(property => property.GetValue(car)))));
