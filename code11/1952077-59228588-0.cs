C#
    class Program
    {
        static void Main(string[] args)
        {
            string a = "-1.5E5";
            bool b = decimal.TryParse(a, out var  d );
        }
    }
