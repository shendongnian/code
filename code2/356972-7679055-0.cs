        static double[,] Intersect(double[,] a1, double[,] a2)
        {
            // Assumptions:
            //      a1 and a2 are two-dimensional arrays of the same size
            //      An element in the array matches if and only if its value is found in the same location in both arrays
            //      result will contain not-a-number (NaN) for non-matches
            double[,] result = new double[a1.GetLength(0), a1.GetLength(1)];
            for (int i = 0; i < a1.GetLength(0); i++)
            {
                for (int j = 0; j < a1.GetLength(1); j++)
                {
                    if (a1[i, j] == a2[i, j])
                    {
                        result[i, j] = a1[i, j];
                    }
                    else
                    {
                        result[i, j] = double.NaN;
                    }
                }
            }
            return result;
        }
