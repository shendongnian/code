       public int diagX()
            {
                int x;
                x = 0;
                
            for (f = 1; f <= filas; f++)
              {
               for (c = columnas; c >= 1; c--)
                   {
                       if (f > c || f < c)
                       {
                           x += a[f, c];
                       }
                       else
                       {
                           continue;
                       }
                    }
              }
            return x;
            }
