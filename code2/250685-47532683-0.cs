    public static double SumRootN(int root)
    {
        double result = 0;
        for (int i = 1; i < 10000000; i++)
			{
                result += Math.Exp(Math.Log(i) / root);
            }
            return result; 
    }
