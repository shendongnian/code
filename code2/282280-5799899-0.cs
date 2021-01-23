    Dictionary<int, int[]> items = new Dictionary<int, int[]>();
    // add an item using a literal array:
    items.Add(42, new int[]{ 1, 2, 3 });
    // create an array and add:
    int[] values = new int[3];
    values[0] = 1;
    values[1] = 2;
    values[2] = 3;
    items.Add(4, values);
    // get one item:
    int[] values = items[42];
