    public class EnemyObject : MonoBehaviour
    {
        ...        
        void OnBecameVisible()
        {
             GameObject something = new GameObject("Something");
             something.transform.parent = this.transform;
        }
        void OnBecameInvisible()
        {
            GameObject something = GameObject.Find("Something");
            Destroy(something);
        }
        
    }
