    public class Player
    {
        private readonly IList<Weapon> _ownedWeapons = new List<Weapon>();
        protected Weapon ActiveWeapon { get; private set; }
    
        public IEnumerable<WeaponName> OwnedWeapons { get; set; }
    
        public event EventHandler<WeaponEventArgs> WeaponGrabbed;
        public event EventHandler<WeaponEventArgs> ActiveWeaponChanged;
    
        public void InvokeActiveWeaponChanged()
        {
            var handler = ActiveWeaponChanged;
            if (handler != null) handler(this, new WeaponEventArgs(ActiveWeapon));
        }
        public void InvokeWeaponGrabbed(Weapon weapon)
        {
            var handler = WeaponGrabbed;
            if (handler != null) handler(this, new WeaponEventArgs(weapon));
        }
    
        public void SwitchWeapon(WeaponName weaponName)
        {
            ActiveWeapon = _ownedWeapons.Where(weapon => weapon.Name == weaponName).First();
            InvokeActiveWeaponChanged();
        }
        public void Grab(Weapon weapon)
        {
            _ownedWeapons.Add(weapon);
            InvokeWeaponGrabbed(weapon);
        }
    }
