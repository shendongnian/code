        List<string> myList= new List<string>(){ "ABC", "DEF", "H" };
        myList.ForEach(Print);
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
