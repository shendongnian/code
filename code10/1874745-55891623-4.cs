    var data = new List<double>();
    foreach (string line in lines)
    {
        string[] values = line.Split(new char[]{' '},
                                     StringSplitOptions.RemoveEmptyEntries);
        foreach (string value in values)
        {
            data.Add(Convert.ToDouble(value));
        }
    }
    double[] dataArray = data.ToArray();
