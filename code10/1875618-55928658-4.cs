    public class SpawnZoneReference : MonoBehaviour
    {
        public static GameObject instance;
        private void Awake ()
        {
            instance = gameObject;
        }
    }
