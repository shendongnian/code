    public class Ninja
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public void SetNinja(Ninja ninja)
        {
            Id = ninja.Id;
            Name = ninja.Name;
        }
    }
