    private static void SortChem(string[,] chem) {
      List<Tuple<string, int>> data = new List<Tuple<string, int>>();
    
      for(int i = 0; i < chem.GetLength(0); ++i)
        data.Add(Tuple.Create(chem[i, 0], int.Parse(chem[i, 1]))); 
    
      int index = 0;
    
      foreach (var tuple in data.OrderByDescending(item => item.Item2)) {
        chem[index, 0] = tuple.Item1; 
        chem[index, 1] = tuple.Item2.ToString();
    
        index += 1; 
      }
    }
