    class Program
    {
        public static string IntegerToExcelColumn(int col)
        {
            Debug.Assert(col >= 1 && col <= 256);
            if (col >= 1 && col <= 26)
            {
                return ((char)(((int)'A') + (col - 1))).ToString();
            }
            if (col > 26 && col <= 256)
            {
                int rem = col % 26;
                int pri = col / 26;
                if (rem == 0)
                {
                    rem = 26;
                    pri--;
                }
                char[] buffer = new char[2];
                buffer[0] = (char)(((int)'A') + (pri - 1));
                buffer[1] = (char)(((int)'A') + (rem - 1));
                return new string(buffer);
            }
            return "";
        }
        static void Main(string[] args)
        {
            string[] columns= new string[255];
            for (int i = 1; i <= 255; i++)
                columns[i-1] = IntegerToExcelColumn(i);
            foreach(var col in columns)
                Console.WriteLine(col);
        }
    }
