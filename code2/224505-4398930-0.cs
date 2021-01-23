    var list = new List<int[]>();
    if (myDataReader.HasRows)
    {
        while (myDataReader.Read())
        {
            var int1 = ??; // Get data 1
            var int2 = ??; // Get data 2
            list.Add(new[] { int1, int2 });
        }
    }
