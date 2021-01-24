    private static  float[,] DifferentiateAsync(int[,] Data, int[,] Filter)
    {
        var Fw = Filter.GetLength(0);
        var Fh = Filter.GetLength(1);
        float[,] Output = new float[Width, Height];
       Parallel.For(Fw / 2, Width - Fw / 2 - 1, (i, state) =>
        {
            unsafe
            {
                for (var j = Fh / 2; j <= (Height - Fh / 2) - 1; j++)
                {
                    var sum = 0;
                    for (var k = -Fw / 2; k <= Fw / 2; k++)
                    {
                        for (var l = -Fh / 2; l <= Fh / 2; l++)
                        {
                            sum = sum + Data[i + k, j + l] * Filter[Fw / 2 + k, Fh / 2 + l];
                        }
                    }
                    Output[i, j] = sum+1;
                }
            }
        });
        return Output;
    }
