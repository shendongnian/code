    double[] values = new double[]
    {
        1.8,
        2.4,
        2.7,
        3.1,
        4.5
    };
    double difference = double.PositiveInfinity;
    int index = -1;
    double input = 2.5;
    for (int i = 0; i < values.Length; i++)
    {
        double currentDifference = Math.Abs(values[i] - input);
        if (currentDifference < difference)
        {
            difference = currentDifference;
            index = i;
        }
        // Stop searching when we've encountered a value larger
        // than the inpt because the values array is sorted.
        if (values[i] > input)
            break;
    }
    Console.WriteLine("Found index: {0} value {1}", index, values[index]);
