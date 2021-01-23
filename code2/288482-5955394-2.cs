        public class Cat
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<Cheezburger> Cheezbugers { get; private set; }
    
            public void AddCheezburger(Cheezburger cheezburger)
            {
                if (this.Cheezbugers == null)
                    this.Cheezbugers = new List<Cheezburger>();
                this.Cheezbugers.Add(cheezburger); 
            }
        };
    
        public class Cheezburger
        {
            public int PattyCount { get; set; }
            public bool CanHaz { get; set; }
        };
