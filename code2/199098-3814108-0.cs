    public int sumarDiagonal()
        {
            int x = 0;
            for (int F = 0; F < Filas; F++)
            {
                for (int c = Columnas-1; c >= 0; c--)
                {
                    if (F == c)
                    {
                        x += m[F,c];
                    }
                }
            }
            return x;
        }
