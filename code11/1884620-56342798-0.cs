    public class WeaponUnlockSystem {
    
    	private Dictionary<string, bool> weaponUnlockState;
    	
    	public WeaponUnlockSystem() 
    	{
    		weaponUnlockState = new Dictionary<string, bool>();
            weaponUnlockState.Add("Shotgun", true);              
            weaponUnlockState.Add("Rifle", true);
            weaponUnlockState.Add("FireballGun", false);
            weaponUnlockState.Add("LaserGun", false);
            weaponUnlockState.Add("FlamethrowerGun", false);
            weaponUnlockState.Add("SuperGun", false);
    	}
    	
    	public bool IsWeaponUnlocked(string weapon)
        {
            if (weaponUnlockState.ContainsKey(weapon))
                return weaponUnlockState[weapon];         
            else
                return false;
        }
    
        public void UnlockWeapon(string weapon) 
        {
            if (weaponUnlockState.ContainsKey(weapon))
                weaponUnlockState[weapon] = true;
        }
    }
    
    public class Player : MonoBehaviour {
    	
    	private WeaponUnlockSystem weaponUnlockSystem;
    	
    	void Start()
    	{
    		weaponUnlockSystem = new WeaponUnlockSystem();
    		...
    	}
    
    	public void NextWeapon(string weapon) 
    	{
    		...
    	}
    }
