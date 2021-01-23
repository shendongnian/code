    class sample
    {
        public string str1 = "";
        public string str2 = "";
        public sample() : this("BB", "EE")
        {
           
        }
        public sample(string s1, string s2)
        {
            this.str1 = s1;
            this.str2 = s2;
        }
        public static void Main()
        {
            sample smpl = new sample();
            Console.WriteLine(smpl.str1);
            Console.WriteLine(smpl.str2);
            Console.ReadLine();
        }
    }
