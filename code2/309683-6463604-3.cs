    public class WeaponRepository 
    {
        readonly Dictionary<WeaponName, Func<Weapon>> _availableWeapons = new Dictionary<WeaponName, Func<Weapon>>();
        
        public WeaponRepository()
        {
            _availableWeapons.Add(WeaponName.Pistol, () => new Weapon(WeaponName.Pistol) );
            _availableWeapons.Add(WeaponName.Shotgun, () => new Weapon(WeaponName.Shotgun) );
        }
        public Weapon Create(WeaponName name)
        {
            return _availableWeapons[name]();
        }
        public IEnumerable<WeaponName> AvailableWeapons()
        {
            return Enum.GetValues(typeof (WeaponName)).Cast<WeaponName>();
        }
        public IEnumerable<WeaponName> WeaponsNotOwnedBy(Player player)
        {
            return AvailableWeapons().Where(weaponName => !player.OwnedWeapons.Contains(weaponName));
        }
    }
