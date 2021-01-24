    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    
    public class DoorsLockManager : MonoBehaviour
    {
        public bool lockDoors = false;
    
        private Renderer rend;
        private Shader unlitcolor;
        private List<GameObject> DoorShieldFXLocked = new List<GameObject>();
        private List<HoriDoorManager> _doors = new List<HoriDoorManager>();
    
        private void Start()
        {
            DoorShieldFXLocked = GameObject.FindGameObjectsWithTag("DoorShield").ToList();
            unlitcolor = Shader.Find("Unlit/ShieldFX");
    
            var doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (var door in doors)
            {
                _doors.Add(door.GetComponent<HoriDoorManager>());
            }
    
            ChangeDoorsLockStates();
        }
    
        private void Update()
        {
            ChangeDoorsLockStates();
        }
    
        private void ChangeDoorsLockStates()
        {
            for (int i = 0; i < DoorShieldFXLocked.Count; i++)
            {
                if (lockDoors == true)
                {
                    ChangeColors(Color.red, Color.green, i);
                }
                else
                {
                    ChangeColors(Color.red, Color.green, i);
                }
            }
    
            for (int x = 0; x < _doors.Count; x++)
            {
                if (lockDoors == true)
                {
                    LockDoor(x);
                }
                else
                {
                    UnlockDoor(x);
                }
            }
        }
    
        private void ChangeColors(Color32 lockedColor, Color32 unlockedColor, int index)
        {
            var renderer = DoorShieldFXLocked[index].GetComponent<Renderer>();
            renderer.material.shader = Shader.Find("Unlit/ShieldFX");
    
            if (lockDoors == true)
            {
                renderer.material.SetColor("_MainColor", lockedColor);
            }
            else
            {
                renderer.material.SetColor("_MainColor", unlockedColor);
            }
        }
    
        public void LockDoor(int doorIndex)
        {
            _doors[doorIndex].ChangeLockState(true);
        }
        public void UnlockDoor(int doorIndex)
        {
            _doors[doorIndex].ChangeLockState(false);
        }
    }
