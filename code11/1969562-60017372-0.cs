    public class Destructible : MonoBehaviour
    {
        // Class based on your code sample above.
        public GameObject destroyedVersion;
        
        void OnMouseDown()
        {
            GameObject destroyedObject = Instantiate(
                destroyedVersion, transform.position, transform.rotation);
            
            Destroyed destroyed = destroyedObject.GetComponent<Destroyed>();
            destroyed.SetOrigin(this);
            
            gameObject.SetActive(false);
        }
    }
    
    public class Destroyed : MonoBehavior
    {
        Destructible destructible = null;
        
        public void SetOrigin(Destructible destructible)
        {
            this.destructible = destructible;
        }
    
    
        // This method can now be called from anywhere to rebuild:    
        public void RebuildOrigin()
        {
            if (destructible != null)
            {
                destructible.gameObject.SetActive(true);
                
                Destroy(gameObject);
            }
        }
    }
