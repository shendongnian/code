    public class A : MonoBehaviour
    {
        // A prefab only this specific component has access to
        [SerializeField] private GameObject prefab;
        // example for a kind of singleton pattern
        private static GameObject prefabSingleton;
        private void Start()
        {
            prefabSingleton = prefab;
        }
        public static void Spawn(int someIntToAssign, string someTextToAssign)
        {
            var obj = Instantiate(prefabSingleton)
;
            componentReference = obj.GetComponent<SomeType>();
            componentReference.someIntField = someIntToAssign;
            componentReference.Getcomponent<Text>().text = someTextToAssign;
        }
    }
