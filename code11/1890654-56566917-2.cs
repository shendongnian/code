    public class Gun
    {
        public int MaxRounds { get; set; }
        public List<Bullet> Ammunition { get; set; } = new List<Bullet>();
        public Gun(int maxRounds)
        {
            MaxRounds = maxRounds;
        }
        public Gun Clone()
        {
            // Create a shallow copy of all the properties
            Gun newGun = MemberwiseClone() as Gun;
            // Because 'Bullet' is a reference type, we need to make a deep copy of 'Ammunition'
            newGun.Ammunition = Ammunition.Select(bullet => bullet.Clone()).ToList();
            return newGun;
        }
    }
    public class Bullet
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public Bullet Clone()
        {
            return MemberwiseClone() as Bullet;
        }
    }
