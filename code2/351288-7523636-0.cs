    class Client {
        public string Name { get; set; }
        public Client(string name) { this.Name = name; }
    }
 
    class Job : Client {
        public Job(string name) : base(name) { }
    }
