        public void match2()
        {
            string input = "%download%#893434";
            Regex word = new Regex(@"\d+");
            Match m = word.Match(input);
            Console.WriteLine(m.Value);
        }
