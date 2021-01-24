    public static class WeaponUnlockSystem
    {
        private static string[] unlockedWeapons = InitialWeapons();
        private static string[] InitialWeapons(){
            string w = new string[]{
                "Shotgun",
                "Rifle",
            }
        }
        public static bool IsWeaponUnlocked(string name)
        {
            int i = 0;
            bool found = false;
            while(i < unlockedWeapons.Length && !found){
                if (string.Equals(unlockedWeapons[i],name)){
                    found = true;
                }
                i++;
            }
            return found;
        }
        public static void UnlockWeapon(string name)
        {
            string[] weapons = new string[unlockedWeapons.Length+1];
            int i = 0;
            bool found = false;
            while(i < unlockedWeapons.Length && !found){
                if (string.Equals(unlockedWeapons[i],name)){
                    found = true;
                } else {
                    weapons[i] = unlockedWeapons[i];
                }
            }
            if(!found){
                weapons[unlockedWeapons.Length] = name;
                unlockedWeapons = weapons;
            }
    }
