    using (TextWriter tw = new StreamWriter("SQL_U.txt"))
    {
        for (int j = 0; j < matrix.ColumnCount; j++)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                if (i != 0)
                {
                    tw.Write(" ");
                }
                tw.Write(U[i, j]);
            }
            tw.WriteLine();
        }
    }
