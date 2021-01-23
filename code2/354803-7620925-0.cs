    StreamReader sr = new StreamReader(@"C:\Users\arash\Desktop\1.txt");
    List<int[]> table = new List<int[]>();
    string line;
    string[] split;
    int[] row;
    while ((line = sr.ReadLine()) != null) {
        split = line.Split(' ');
        row = new int[split.Count];
        for (int x = 0; x < split.Count; x++) {
            row[x] = Convert.ToInt32(split[x]);
        }
        table.Add(row);
    }
