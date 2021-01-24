    public class ClassB : MonoBehaviour
    {
        void Start(){
            ClassA instance = new ClassA(gameObject);
            instance.Foo(new Vector3(10.5f,15.2f,20.8f));
        }
        public static int Floor(float x) // 10.5f and 12.19f
        {
            int xi = (int)x;
            return x < xi ? xi - 1 : xi;
        }
    }
    
    
    public class ClassA
    {
        private GameObject gameObject;
        public ClassA(GameObject go){
            gameObject = go;
        }
        public byte Foo(Vector3 pos) // new Vector3(10.5f,15.2f,20.8f)
        {
            int x = ClassB.Floor(pos.x);  // 10
            //Debug.Log(x);
            Vector3 objPosition = gameObject.transform.position; // new Vector3(12.19f, 1f, -10f);
            float xx = objPosition.x; // 12.19f
            int px = ClassB.Floor(xx); //12
            //Debug.Log(px);
            return new byte();
        }
    }
