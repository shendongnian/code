C#
    class Program
    {
        static void Main(string[] args)
        {
            string a = "-1.5E5";
            bool b = decimal.TryParse(a, out var  d );
        }
    }
ps. decimal parse `-1.5E5` will get `0`,avoid this situation you colud use `double.Parse`
