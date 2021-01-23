    public class Weapon
    {
        public Weapon(WeaponName name)
        {
            Name = name;
        }
        public WeaponName Name { get; set; }
        public int Priority { get; set; }
        public int MaxAmmoQuantity { get; set; }
        public int CurrentAmmoQuantity { get; set; }
        public override string ToString()
        {
            return Enum.GetName(typeof(WeaponName), Name);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var other = obj as Weapon;
            if (other == null) return false;
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
