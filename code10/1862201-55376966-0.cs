    [ExecuteInEditMode]
    public class DoorsLockManager : MonoBehaviour
    {
        [HideInInspector]
        public List<HoriDoorManager> Doors = new List<HoriDoorManager>();
        // The global state
        [SerializeField] private bool GlobalLockState;
    
        // In a build use this method instead
        public void SetGlobalLockState(bool state)
        {
        
            foreach(var door in Doors)
            {
                // now you would need it public again
                // or use the public property you had there
                Door.doorLockState = state;
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
    
