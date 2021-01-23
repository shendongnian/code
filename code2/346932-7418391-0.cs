            static void Main(string[] args)
        {
            Regex regex = new Regex(@"\,");
            Console.WriteLine(regex.Replace("sample, text", string.Empty));
            Console.ReadLine();
        }
