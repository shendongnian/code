    public class GlobalSingleton<T> : MonoBehaviour
        where T : GlobalSingleton<T>
    {
        static T s_instance = null;
        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    GameObject prefab = Resources.Load(typeof(T).Name) as GameObject;
                    if (prefab == null || prefab.GetComponent<T>() == null)
                    {
                        Debug.LogError("Prefab for game manager " + typeof(T).Name + " is not found");
                    }
                    else
                    {
                        GameObject gameManagers = GameObject.Find("GameManagers");
                        if (gameManagers == null)
                        {
                            gameManagers = new GameObject("GameManagers");
                            DontDestroyOnLoad(gameManagers);
                        }
                        GameObject gameObject = Instantiate(prefab);
                        gameObject.transform.parent = gameManagers.transform;
                        s_instance = gameObject.GetComponent<T>();
                        s_instance.Init();
                    }
                }
                return s_instance;
            }
        }
       protected virtual void Init()
       { }
    }
