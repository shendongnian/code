    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public enum Sex { Male, Female, Other };
        public Weapon Weapon { get; set; }
    }
    public class Weapon
    {
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int Range { get; set; }
        public WeaponClass Class { get; set; }
        public enum WeaponClass { Sword, Club, Bow }
    }
