    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*status read good");
            sb.AppendLine("status1 unread bad");
            sb.AppendLine("status2 null cantsay*");
            string input = sb.ToString();
            var startPos = input.IndexOf("status1");
            var endPos = input.IndexOf(Environment.NewLine, startPos);
            var modifiedInput = input.Replace(oneLine.Substring(startPos, endPos - startPos), "status1 read good");
            Console.WriteLine(modifiedInput);
            Console.ReadKey();
        }
    }
