    Complex SolvePQ(double p, double q)
    {
        ...
        return new Complex(real, imag);
    }
    ...
    var solution = SolvePQ(...);
    Console.WriteLine("{0} + {1}i", solution.Real, solution.Imaginary);
