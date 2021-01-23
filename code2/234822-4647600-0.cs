        static bool IsEqual(String left, String right)
        {
            left = Regex.Replace(left, ":[0-9]*:[0-9]*", "");
            right = Regex.Replace(right, ":[0-9]*:[0-9]*", "");
            return left.Equals(right);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsEqual("SAAT:232:34", "SAAT:12:23")); // True
            Console.WriteLine(IsEqual("PAAT:23:34", "SAAT:12:23")); // False
            Console.WriteLine(IsEqual("SAAT:23:34:HAT", "SAAT:12:23:HAT")); // True
        }
