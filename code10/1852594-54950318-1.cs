    List<double[][]> ReadFromFile(string fileName)
    {
      var output = new List<double[][]>();
      using (var r = new StreamReader(fileName))
      {
        int outputCount = int.Parse(r.ReadLine());
        for (int c = 0; c < outputCount; c++)
        {
          var weight2D = new double[int.Parse(r.ReadLine())][];
          for (int d = 0; d < weight2D.Length; d++)
          {
            weight2D[d] = new double[int.Parse(r.ReadLine())];
            for (int i = 0; i < weight2D[d].Length; i++)
            {
              weight2D[d][i] = double.Parse(r.ReadLine(), CultureInfo.InvariantCulture);
            }
          }
          output.Add(weight2D);
        }
      }
      return output;
    }
