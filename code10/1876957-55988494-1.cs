    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    
    public class ShootingManager : MonoBehaviour
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
        //Making it public so you can drag and drop the   
        //references in the inspector
        public List<Shooting> shooters; 
    
        // Start is called before the first frame update
        void Start()
        {
            ShootingSettings();
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        public void ShootingSettings()
        {
            for (int i = 0; i < shooters.Count; i++)
            {
                shooters[i].launchForce = launchForce;
                shooters[i].automaticFire = automaticFire;
                shooters[i].bulletDestructionTime = bulletDestructionTime;
                shooters[i].maxDrag = maxDrag;
                shooters[i].bulletSpeed = bulletSpeed;
                shooters[i].bulletsSlowDown = bulletsSlowDown;
                shooters[i].overAllSlowdown = overAllSlowdown;
                shooters[i].slowdownAll = slowdownAll;
            }
        }
    }
