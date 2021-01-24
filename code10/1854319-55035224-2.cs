    // CreateAssetMenu is what lets you create an instance of a Weapon in your Project
    // view.  Make a folder for your weapons, then right click inside that folder (in the 
    // Unity project view) and there should be a menu option for Equipment -> Create Weapon
    [CreateAssetMenu(menuName = "Equipment/Create Weapon")]
    public class Weapon : Equipment
    {
        public int attackPower;    
        public int attackSpeed;
        public WeaponTypes weaponType;
    }
    
    public enum WeaponTypes
    {
        Axe,
        Bow,
        Sword
    }
