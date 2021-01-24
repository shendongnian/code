    [ExecuteInEditMode]
    public class DoorsLockManager : MonoBehaviour
    {
        [HideInInspector]
        public List<HoriDoorManager> Doors = new List<HoriDoorManager>();
        // The global state
        [SerializeField] private bool _globalLockState;
    
        // During runtime use a property instead
        public bool GlobalLockState
        {
            get { return _globalLockState; }
            set 
            {
                _globalLocakState = value;            
 
                // apply it to all doors
                foreach(var door in Doors)
                {
                    // now you would need it public again
                    // or use the public property you had there
                    Door.doorLockState = _globalLocakState;
                }
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
    
