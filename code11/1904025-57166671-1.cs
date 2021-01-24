    [JsonConverter(typeof(ArchetypeConverter))]
    public class Archetype
    {
        public int id { get; set; }
        public string name { get; set; }
        public int player_class { get; set; }
        public string player_class_name { get; set; }
        public List<int> components { get; set; }
    }
