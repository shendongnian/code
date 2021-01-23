    using System;
    using System.Diagnostics;
    namespace ConsoleApplication15
    {
        class Program
        {
            static void Main(string[] args)
            {
                RowOrCol[] rows = new RowOrCol[] { 
                    new RowOrCol(4, 1),
                    new RowOrCol(5, 1),
                    new RowOrCol(4, 2),
                    new RowOrCol(8, 0),
                    new RowOrCol(3, 2),
                };
                RowOrCol[] cols = new RowOrCol[] { 
                    new RowOrCol(5, 1),
                    new RowOrCol(3, 2),
                    new RowOrCol(4, 2),
                    new RowOrCol(5, 1),
                    new RowOrCol(7, 0),
                };
                int[,] table = new int[5, 5];
                Stopwatch sw = Stopwatch.StartNew();
                int solutions = Do(table, rows, cols, 0, 0);
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine("Found {0} solutions in {1}ms", solutions, sw.ElapsedMilliseconds);
                Console.ReadKey();
            }
            public static int Do(int[,] table, RowOrCol[] rows, RowOrCol[] cols, int row, int col)
            {
                int solutions = 0;
                int oldValueRowSum = rows[row].Sum;
                int oldValueRowZero = rows[row].Zeros;
                int oldValueColSum = cols[col].Sum;
                int oldValueColZero = cols[col].Zeros;
                int nextCol = col + 1;
                int nextRow;
                bool last = false;
                if (nextCol == cols.Length)
                {
                    nextCol = 0;
                    nextRow = row + 1;
                    if (nextRow == rows.Length)
                    {
                        last = true;
                    }
                }
                else
                {
                    nextRow = row;
                }
                int i;
                for (i = 0; i <= 3; i++)
                {
                    table[row, col] = i;
                    if (i == 0)
                    {
                        rows[row].Zeros--;
                        cols[col].Zeros--;
                        if (rows[row].Zeros < 0)
                        {
                            continue;
                        }
                        if (cols[col].Zeros < 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (i == 1)
                        {
                            rows[row].Zeros++;
                            cols[col].Zeros++;
                        }
                        rows[row].Sum--;
                        cols[col].Sum--;
                        if (rows[row].Sum < 0)
                        {
                            break;
                        }
                        else if (cols[col].Sum < 0)
                        {
                            break;
                        }
                    }
                    if (col == cols.Length - 1)
                    {
                        if (rows[row].Sum != 0 || rows[row].Zeros != 0)
                        {
                            continue;
                        }
                    }
                    if (row == rows.Length - 1)
                    {
                        if (cols[col].Sum != 0 || cols[col].Zeros != 0)
                        {
                            continue;
                        }
                    }
                    if (!last)
                    {
                        solutions += Do(table, rows, cols, nextRow, nextCol);
                    }
                    else 
                    {
                        solutions++;
                        Console.WriteLine("Found solution:");
                        var sums = new int[cols.Length];
                        var zeross = new int[cols.Length];
                        for (int j = 0; j < rows.Length; j++)
                        {
                            int sum = 0;
                            int zeros = 0;
                            for (int k = 0; k < cols.Length; k++)
                            {
                                Console.Write("{0,2} ", table[j, k]);
                                if (table[j, k] == 0)
                                {
                                    zeros++;
                                    zeross[k]++;
                                }
                                else
                                {
                                    sum += table[j, k];
                                    sums[k] += table[j, k];
                                }
                            }
                            Console.WriteLine("| Sum {0,2} | Zeros {1}", sum, zeros);
                            Debug.Assert(sum == rows[j].OriginalSum);
                            Debug.Assert(zeros == rows[j].OriginalZeros);
                        }
                        Console.WriteLine("---------------");
                        for (int j = 0; j < cols.Length; j++)
                        {
                            Console.Write("{0,2} ", sums[j]);
                            Debug.Assert(sums[j] == cols[j].OriginalSum);
                        }
                        Console.WriteLine();
                        for (int j = 0; j < cols.Length; j++)
                        {
                            Console.Write("{0,2} ", zeross[j]);
                            Debug.Assert(zeross[j] == cols[j].OriginalZeros);
                        }
                        Console.WriteLine();
                    }
                }
                // The for cycle was broken at 0. We have to "readjust" the zeros.
                if (i == 0)
                {
                    rows[row].Zeros++;
                    cols[col].Zeros++;
                }
                // The for cycle exited "normally". i is too much big because the true last cycle was at 3.
                if (i == 4)
                {
                    i = 3;
                }
                // We readjust the sums.
                rows[row].Sum += i;
                cols[col].Sum += i;
                Debug.Assert(oldValueRowSum == rows[row].Sum);
                Debug.Assert(oldValueRowZero == rows[row].Zeros);
                Debug.Assert(oldValueColSum == cols[col].Sum);
                Debug.Assert(oldValueColZero == cols[col].Zeros);
                return solutions;
            }
        }
        public class RowOrCol
        {
            public readonly int OriginalSum;
            public readonly int OriginalZeros;
            public int Sum;
            public int Zeros;
            public RowOrCol(int sum, int zeros)
            {
                this.Sum = this.OriginalSum = sum;
                this.Zeros = this.OriginalZeros = zeros;
            }
        }
    }
