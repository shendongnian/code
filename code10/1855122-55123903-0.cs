    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Dragons : MonoBehaviour {
        // same as GoldDragonInit
        bool GoldDragonSpawn = false;
        // same number as DragonCount in DragonTrackeer
        int LiveDragons;
        // same as Difficulty
        int DifLev;
        void Start()
        {
            // variables from other script
         GetComponentInParent<DragonTracker>().GoldDragonInit = GoldDragonSpawn;
        }
        System.Random RNG= new System.Random();
        void update()
        {
            RSpawn=RNG.Next(0,2);
            DragonType=RNG.Next(0,101);
            if (RSpawn = 1)
            {
                if (LiveDragons > DifLev)
                {
                    if (DragonType > 99)
                    {
                        // summon regular dragon
                    }
                    if (DragonType = 100)
                    {
                        if (GoldDragonSpawn = true)
                        {
                            // summon gold dragon
                        }
                    }
                }
            }
        }
    }
