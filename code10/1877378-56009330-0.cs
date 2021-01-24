    static class Program
    {
        static void Main(string[] args)
        {
            // Write code here:
            var grid = new string[,] {
                {  "A", "B", "C", "D" },
                {  "P", "R", "A", "T" },
                {  "K", "I", "T", "A" },
                {  "A", "N", "D", "Y" }};
            Console.WriteLine(string.Join("|", grid.FindDiagonalWords(2, 1)));
            // (2,1) "I" => "PID|DAIA"
        }
        public static IEnumerable<string> FindDiagonalWords(this string[,] grid, int row, int column)
        {
            int numRows = grid.GetLength(0);
            int numCols = grid.GetLength(1);
            var sb = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                int j = (i-row)+column;
                if (j>=0 && j<numCols)
                {
                    sb.Append(grid[i, j]);
                }
            }
            yield return sb.ToString();
            sb.Clear();
            for (int i = 0; i < numRows; i++)
            {
                int j = row+column-i;
                if (j>=0 && j<numCols)
                {
                    sb.Append(grid[i, j]);
                }
            }
            yield return sb.ToString();
        }
    }
