    public class SomeClass : MonoBehaviour {
        private static SomeClass _instance;
        public String text = "singleton text";
        public static SomeClass Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }
    }
