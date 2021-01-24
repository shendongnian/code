    // Summation of all cells in a matrix, just a quick verification check.
    // The intent is to verify that when a matrix is read from the database,
    // the reconstructed matrix has the same checksum as the one that was saved.
    //
        public double computeChecksum(double[,] dblArray)
        {
            int rank = dblArray.Rank; // rank is the number of dimensions of an array.
            int rows = dblArray.GetLength(0);
            int cols = dblArray.GetLength(1);
            double sum = 0.0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    sum += dblArray[r, c];
                }
            }
            return sum;
        }
    }
