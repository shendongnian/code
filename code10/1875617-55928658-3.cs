        public GameObjectReferenceSetter : MonoBehaviour
        {
            [SerializeField] private GameObject scriptableAsset;
            private void Awake()
            {
                scriptableAsset.value = gameObject;
            }
        }
