    public enum WeaponType {
        Fists,
        Sword,
        Bow, 
        Staff
    }
    public class WeaponFactory {
        public Weapon Create(WeaponType weaponType) {
            switch(weaponType) {
                case WeaponType.Fists:
                    return new WeaponFists();
                case WeaponType.Sword:
                    return new WeaponSword();
                case WeaponType.Bow:
                    return new WeaponBow();
                case WeaponType.Staff:
                    return new WeaponStaff();
                default:
                    throw new ArgumentOutOfRangeException("weaponType");
            }
        }
    }
