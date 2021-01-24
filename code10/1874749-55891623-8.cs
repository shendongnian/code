    var data = new List<double>();
    foreach (string line in lines)
    {
        string[] values = line.Split(new char[]{' '},
                                     StringSplitOptions.RemoveEmptyEntries);
        if (values.Length > 0) { // Just in case the last line is empty.
            data.Add(Convert.ToDouble(values[0]));
        }
    }
    double[] dataArray = data.ToArray();
