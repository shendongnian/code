    public class Objective
    {
        public Objective(string name)
        {
            Name = name;
            Objectives = new List<Objective>();
        }
        public string Name { get; set; }
        public List<Objective> Objectives { get; set; }
    }
