     using System.Linq;
     ... 
     int index = 0;
     foreach (var tuple in data.OrderByDescending(item => item.Item2)) {
       chem[index, 0] = tuple.Item1; 
       chem[index, 1] = tuple.Item2.ToString();
       index += 1; 
     }
