    var data = new double[numberOfBuffers * samplesperbuffer];
    int k = 0;
    foreach (string line in lines)
    {
        string[] values = line.Split(new char[]{' '},
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string value in values)
        {
            data[k++] = Convert.ToDouble(value));
        }
    }
