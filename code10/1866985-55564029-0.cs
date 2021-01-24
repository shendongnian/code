    public class Example : MonoBehaviour
    {
        public BoxCollider2D box01;
        public BoxCollider2D box02;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.IsTouching(box01))
            {
                Debug.Log("1");
            }
            else if(collision.IsTouching(box02))
            {
                Debug.Log("2");
            }
        }
    }
