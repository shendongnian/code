    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [DontSendInPublicApi]
        public string Occupation { get; set; }
        [DontSendInPublicApi]
        public int Salary { get; set; }
    }
