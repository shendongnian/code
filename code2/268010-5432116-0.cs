    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
    }
    [Serializable]
    public class Weapon
    {
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int Range { get; set; }
        public WeaponClass Class { get; set; }
        public enum WeaponClass { Sword, Club, Bow }
    }
