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
            g1.AddComponent<something1>();
            GameObject g2 = new GameObject();
            g2.AddComponent<something1>();
            GameObject g3 = new GameObject();
            g3.AddComponent<something2>();
            GameObject g4 = new GameObject();
            g4.AddComponent<something2>();
           
            ...
            g1.SendMessage("Dosomething"); 
            g2.SendMessage("Dosomething"); 
            g3.SendMessage("Dosomething"); 
            g4.SendMessage("Dosomething"); 
        }
    }
