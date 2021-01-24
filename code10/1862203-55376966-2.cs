    [ExecuteInEditMode]
    public class DoorsLockManager : MonoBehaviour
    {
        [HideInInspector]
        public List<HoriDoorManager> Doors = new List<HoriDoorManager>();
        // The global state
        [SerializeField] private bool _globalLockState;
    
        // In a build use this property instead
        public bool GlobalLockState
        {
            get { return _globalLockState; }
            set 
            {
                // apply it to all doors
                foreach(var door in Doors)
                {
                    // now you would need it public again
                    // or use the public property you had there
                    Door.doorLockState = state;
                }
                _globalLocakState = value;
            }
        }
        private void Awake()
        {
            var doors = GameObject.FindGameObjectsWithTag("Door");
            Doors = new HoriDoorManager[doors.Length].ToList();
    
            for (int i = 0; i < doors.Length; i++)
            {
                Doors[i] = doors[i].GetComponent<HoriDoorManager>();
            }
        }
    }
    
