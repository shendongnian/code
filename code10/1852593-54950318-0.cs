    void SaveToFile(string fileName, List<double[][]> weightsList)
    {
      using (var w = new StreamWriter(fileName))
      {
        w.WriteLine(weightsList.Count);
        foreach (var weight2D in weightsList)
        {
          w.WriteLine(weight2D.Length);
          foreach (var weight1D in weight2D)
          {
            w.WriteLine(weight1D.Length);
            foreach (var val in weight1D)
            {
              w.WriteLine(val.ToString(CultureInfo.InvariantCulture));
            }
          }
        }
      }
    }
