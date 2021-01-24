    private static double CalculateL(double p, int maxsteps)
    {
        double val = 1 / (p + 1);
        for (int i = 1; i < maxsteps; ++i)
        {
            val = 1 / (p + val);
        }
        return val;
    }
