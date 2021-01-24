    public static double FNorm2(double[,] mat)
    {
        double ats = 0.0;
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                ats += mat[i, j]*mat[i, j];
            }
        }
        return Math.Sqrt(ats);
    }
