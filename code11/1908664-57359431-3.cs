    public class Weapon
    {
        public WeaponData weapon = Library.Weapons["shotgun"];
    
        public void Shoot()
        {
            GameObject.Instantiate(
                Resources.Load<Projectile>(Library.Projectiles[weapon.projectileId].prefabPath)
            );
        }
    }
