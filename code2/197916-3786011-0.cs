     class Test
    {
        static void Main(string[] args)
        {
            string s = "john_smith123@yahoo.com";
            int indexof_attherate = s.IndexOf('@');
            string textUpto_attherate = s.Substring(0, indexof_attherate);
            Console.WriteLine(textUpto_attherate);
            Console.Read();
        }
    }
