        interface IHero12
        {
            string skill1 { get; set; }
            string skill2 { get; set; }
        }
        interface IHero1234: IHero12
        {
            string skill3 { get; set; }
            string skill4 { get; set; }
        }
        interface IHero12345: IHero1234
        {
            string skill5 { get; set; }
        }
        class Batman : IHero1234
        {
            public string skill1 { get; set; }
            public string skill2 { get; set; }
            public string skill3 { get; set; }
            public string skill4 { get; set; }
        }
        class Robin : IHero12345
        {
            public string skill5 { get; set; }
            public string skill3 { get; set; }
            public string skill4 { get; set; }
            public string skill1 { get; set; }
            public string skill2 { get; set; }
        }
