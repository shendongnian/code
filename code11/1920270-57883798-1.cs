      // Check box and its corresponding value
      private Tuple<CheckBox, int>[] map => new Tuple<CheckBox, int>[] {
        Tuple.Create(checkBox1, 3),
        Tuple.Create(checkBox2, 2),
        Tuple.Create(checkBox3, 1), 
      };
      // Now we can query the collection with a help of Linq
      private int[] mapBoxes() => map
        .Select(pair => pair.Item1.Checked ? pair.Item2 : 0)
        .ToArray();
      ...
      int[] values = mapBoxes();
