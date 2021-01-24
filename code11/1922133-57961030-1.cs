    public class Individual
    {
      public double[] Numbers { get; set; }
      public Individual()
      {
        Numbers = new double[0];
      }
      public Individual(double[] values)
      {
        Numbers = values/*.ToArray() if a copy must be done*/;
      }
    }
    class Program
    {
      static void Main()
      {
        // Populate data
        var selection = new List<Dictionary<int, Individual>>();
        var dico1 = new Dictionary<int, Individual>();
        var dico2 = new Dictionary<int, Individual>();
        selection.Add(dico1);
        selection.Add(dico2);
        dico1.Add(1, new Individual(new double[] { 1.2, 1.3, 4.0, 10, 40 }));
        dico1.Add(2, new Individual(new double[] { 1.2, 1.5, 4.0, 20, 40 }));
        dico2.Add(3, new Individual(new double[] { 1.7, 1.6, 5.0, 30, 60 }));
        // Count distinct
        var found = new List<double>();
        foreach ( var dico in selection )
          foreach ( var item in dico )
            foreach ( var value in item.Value.Numbers )
              if ( !found.Contains(value) )
                found.Add(value);
        // Must show 12
        Console.WriteLine("Distinct values of the data pool = " + found.Count);
        Console.ReadKey();
      }
    }
