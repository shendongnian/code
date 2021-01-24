    [CreateAssetMenu (fileName = "new ShootingSettings", menuName = "ShootingSettings")]
    public class ShootingSettings : ScriptableObject
    {      
        [Header("Main")]
        public float launchForce = 700f;
        public bool automaticFire = false;
        public float bulletDestructionTime;
        [Space(5)]
        [Header("Slow Down")]
        public float maxDrag;
        public float bulletSpeed;
        public bool bulletsSlowDown = false;
        public bool overAllSlowdown = false;
        [Range(0, 1f)]
        public float slowdownAll = 1f;
    }
