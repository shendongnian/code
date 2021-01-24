        class Valuegroup
        {
            public int FirsValue { get; set; }
            public int SecondValue { get; set; }
        }
        static void Main(string[] args)
        {
            //Variable 1 = (2, 4) , (5, 1)
            Valuegroup first = new Valuegroup
            {
                FirsValue = 2,
                SecondValue = 4
            };
            Valuegroup second = new Valuegroup
            {
                FirsValue = 5,
                SecondValue = 1
            };
            Dictionary<string, List<Valuegroup>> myList = new Dictionary<string, List<Valuegroup>>();
            myList.Add("Variable 1",new List<Valuegroup>{first,second});
            //retrive a value using a key name eg Variable 1
            List<Valuegroup> temp = new List<Valuegroup>();
            myList.TryGetValue("Variable 1", out temp);
            //do a search using Linq
            var t = myList.Where(x => x.Key == "Variable 2");
        } 
