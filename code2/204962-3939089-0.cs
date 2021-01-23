    public class Program
    {
        public static void Main(string[] args)
        {
            bool?[,] bools = new bool?[,] { { true, null }, { false, true } };
            for (int i = 0; i < bools.GetLength(0); i++)
            {
                for (int j = 0; j < bools.GetLength(1); j++)
                {
                    if (bools[i, j] == null)
                        Console.WriteLine("Index of null value: (" + i + ", " + j + ")");
                }
            }
        }
    }
