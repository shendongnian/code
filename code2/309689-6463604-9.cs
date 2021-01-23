    public class WeaponToolbarBuilder
    {
        private readonly Player _player;
        private readonly WeaponRepository _weaponRepository;
        private List<WeaponButton> _buttons = new List<WeaponButton>();
        public WeaponToolbarBuilder(Player player, WeaponRepository weaponRepository)
        {
            _player = player;
            _weaponRepository = weaponRepository;
            _player.ActiveWeaponChanged += _player_ActiveWeaponChanged;
            _player.WeaponGrabbed += _player_WeaponGrabbed;
        }
        void _player_WeaponGrabbed(object sender, WeaponEventArgs e)
        {
            var weaponButton = _buttons.Where(button => button.WeaponName == e.Weapon.Name).First();
            weaponButton.Enable();
        }
        void _player_ActiveWeaponChanged(object sender, WeaponEventArgs e)
        {
            var currentActiveButton = _buttons.Where(button => button.Highlighted).First();
            currentActiveButton.Highlight(false);
            var newActiveButton = _buttons.Where(button => button.WeaponName == e.Weapon.Name);
            newActiveButton.Highlight(true);
        }
        public void BuildToolbar() { ... }
    }
