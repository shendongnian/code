    public class A1 : MonoBehaviour
    {
        User1 user = new User1();
    
        private void Start()
        {
            user.Start();
        }
        public void OnMouseDown()
        {
            Debug.Log(user.BB);
        }
    }
