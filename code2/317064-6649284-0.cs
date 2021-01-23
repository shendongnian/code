    static void SO6648999()
        {
            List<test> sample = new List<test> 
                {
                new test {  debut = 0,
                            end = 4,
                            comment = "y"},
                new test {  debut = 5,
                            end = 10,
                            comment = "x"}
                };
            int number = 4;
            string comment = sample.Single(x => number >= x.debut && number <= x.end).comment;
        }
        class test
        {
            public int debut;
            public int end;
            public string comment;
        }
