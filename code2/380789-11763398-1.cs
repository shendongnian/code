    Tuple<double, double> SolvePQ(double p, double q)
    {
        ...
        return Tuple.Create(real, imag);
    }
    ...
    var solution = SolvePQ(...);
    Console.WriteLine("{0} + {1}i", solution.Item1, solution.Item2);
