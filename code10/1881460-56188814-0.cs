    public class DamageTrap : MonoBehaviour
    {    
        void OnTriggerEnter2D (Collider2D col)
        { 
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("Collision");
            }
        }
    }
