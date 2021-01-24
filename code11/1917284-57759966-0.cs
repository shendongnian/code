public class PrefabHolder : MonoBehaviour //assign all necessary prefabs here, also used for logging on mobileDebugText
    {
     public static PrefabHolder instance;
        
     public GameObject prefabXYZ;
        private void Awake()
        {
            instance = this;
        }
Acess any model you want from any script with Prefabholder.instance.prefabXYZ
