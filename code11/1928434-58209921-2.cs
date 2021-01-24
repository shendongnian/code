    public class something1 : MonoBehaviour
    {
        public void Dosomething(){
        }
    }
    public class something2 : MonoBehaviour
    {
        public void Dosomething(){
        }
    }
    public class callingDoSometing
    {
        public void callALLDosomething(){
            GameObject g1 = new GameObject();
            MonoBehaviour m1 = g1.AddComponent<something1>();
            GameObject g2 = new GameObject();
            MonoBehaviour m2 = g2.AddComponent<something1>();
            GameObject g3 = new GameObject();
            MonoBehaviour m3 = g3.AddComponent<something2>();
            GameObject g4 = new GameObject();
            MonoBehaviour m4 = g4.AddComponent<something2>();
           
            ...
            m1.Invoke("Dosomething",0f);
            m2.Invoke("Dosomething",0f);
            m3.Invoke("Dosomething",0f);
            m4.Invoke("Dosomething",0f);
        }
    }
