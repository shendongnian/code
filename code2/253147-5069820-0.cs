    static Regex codeRegex = new Regex("^code [\\d]+", RegexOptions.Compiled);
        static void Main(string[] args)
        {
            String line;
            String path = "c:/sample.txt";
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(path);
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                if (codeRegex.IsMatch(line))
                    continue;
                if (string.IsNullOrEmpty(line))
                {
                    System.Console.Write(sb.ToString().Trim() + Environment.NewLine);
                    sb.Clear();
                }
                else
                {
                    sb.Append(line);
                    sb.Append("\t");
                }
            }
            if (!string.IsNullOrEmpty(sb.ToString().Trim()))
                System.Console.Write(sb.ToString().Trim() + Environment.NewLine);
        }
