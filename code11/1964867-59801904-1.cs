    using UnityEngine;
    
    public class ShotgunController : WeaponController
    {
        [SerializeField] GameObject bulletShellPrefab = null;
        protected override void Fire()
        {
            base.Fire();
            EmitBulletShell();
        }
        void EmitBulletShell()
        {
            // Maybe you only want shotguns to emit bullet shells,
            // so that code goes here.
        }
        
        // etc.
    }
