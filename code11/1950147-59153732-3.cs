      using System.IO;
      using System.Linq;
      ...
      File.WriteAllLines(@"D:\WriteLines.txt", cars
        .Select(car => string.Join(",", properties
           .Select(property => property.GetValue(car)))));
