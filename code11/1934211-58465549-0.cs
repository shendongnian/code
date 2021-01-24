    using UnityEngine;
    public class SingletonPattern<T> : MonoBehaviour, ISingleton where T : MonoBehaviour
    {
        #region Static Fields
    
        private static T instance = null;
    
        #endregion
    
        #region Fields
        [SerializeField]
        protected bool destroyOnLoad = true;
        private Transform m_transform = null;
        private GameObject m_gameObject = null;
    
        private bool m_isInitialized = false;
    
        #endregion
    
        #region Static Properties
        public static bool HasInstance
        {
            get { return instance != null; }
        }
        /// <summary>
        /// Gets the singleton instance which will be persistent until Application quits.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
    
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    // We need to create new instance
                    if (instance == null)
                    {
                        var _singletonType = typeof(T);
                        // First search in resource if prefab exists for this class
                        string _singletonName = _singletonType.Name;
                        GameObject _singletonPrefab = Resources.Load("Singleton/" + _singletonName, typeof(GameObject)) as GameObject;
    
                        if (_singletonPrefab != null)
                        {
                            Debug.Log(string.Format("[SingletonPattern] Creating singeton {0} using prefab",_singletonName));
                            instance = (Instantiate(_singletonPrefab) as GameObject).GetComponent<T>();
                        }
                        else
                        {
                            instance = new GameObject().AddComponent<T>();
                        }
    
                        // Update name 
                        instance.name = _singletonName;
                    }
                }
    
                return instance;
            }
    
            private set
            {
                instance = value;
            }
        }
    
        #endregion
    
        #region Properties
    
        public Transform CachedTransform
        {
            get
            {
                if (m_transform == null)
                {
                    m_transform = transform;
                }
    
                return m_transform;
            }
        }
    
        public GameObject CachedGameObject
        {
            get
            {
                if (m_gameObject == null)
                {
                    m_gameObject = gameObject;
                }
    
                return m_gameObject;
            }
        }
    
        #endregion
    
        #region MonoCallbacks
    
        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
    
            if (!m_isInitialized)
            {
                Init();
            }
        }
    
        protected virtual void Start()
        { }
    
        protected virtual void Reset()
        {
            // Reset properties
            m_gameObject = null;
            m_transform = null;
            m_isInitialized = false;
        }
    
        protected virtual void OnEnable()
        { }
    
        protected virtual void OnDisable()
        { }
    
        protected virtual void OnDestroy()
        {
        }
    
        protected virtual void OnApplicationQuit()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    
        #endregion
    
        #region Methods
    
        protected virtual void Init()
        {
            // Set as initialized
            m_isInitialized = true;
    
            // Just in case, handling so that only one instance is alive
            if (instance == null)
            {
                instance = this as T;
            }
            // Destroying the reduntant copy of this class type
            else if (instance != this)
            {
                Destroy(CachedGameObject);
                return;
            }
    
            // Set it as persistent object
            if (!destroyOnLoad)
            {
                DontDestroyOnLoad(CachedGameObject);
            }
        }
    
        public void ForceDestroy()
        {
    
            // Destory
            Destroy(CachedGameObject);
        }
    
        #endregion
    }
