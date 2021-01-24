    public class FootballTeam
    {
        private readonly List<Person> _roster = new List<Person>();
        public FootballTeam(string name, Person owner)
        {
            Name = name;
            Owner = owner;
        }
    
        public string Name {get;}
    
        public Person Trainer {get; set;}
    
        public Person Owner {get; set;}
    
        public IEnumerable<Person> Roster => _roster.AsReadOnly();
    
        public void AddPlayer(Person player) {
           _roster.Add(player);
           //Other logic
        }
    
        public void RemovePlayer(Person player) {
           //What if the player isn't on our roster?
           //Other logic?
           _roster.Remove(player);
        }
    
        public void ReplaceRoster(IEnumerable<Person> players) {
           _roster.Clear();
           _roster.AddRange(players);
        }
    }
