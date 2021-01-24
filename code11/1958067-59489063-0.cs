    using System.Linq;
    ...
    List<string> source = new List<string>() {
      "Test;12345",
      "Test;6789",
      "Test;101112",
    
      "Demo;1", 
      "Demo;2", 
    };
    
    List<string> result = source
      .Select(line => line.Split(new char[] {';'}, 2))
      .GroupBy(line => line[0], line => line[1])
      .Select(group => $"{group.Key};{string.Join(";", group)}") 
      .ToList();
