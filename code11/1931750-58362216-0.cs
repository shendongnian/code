    public class Animal : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("Code here in awake is executed by unity the first time this object is activated, and never again in the lifetime of this object.");
        }
    
        void Start()
        {
            Debug.Log("Start is similar to awake but is executed after 'Awake' is executed on all game objects.");
        }
       
        void OnEnable()
        {
            Debug.Log("Code executed EVERYTIME your object is activated, including the first time you enter playmode, provided this object is active.");
        }
      
        void OnDisable()
        {
            Debug.Log("Code executed EVERYTIME your object is deactivated, does not include the first time you enter playmode if the object was disabled before playing.");
        }
        
    }
