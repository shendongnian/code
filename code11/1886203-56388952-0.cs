    public class Plane : MonoBehaviour {
    
        public PlaneEvent OnDestroyed;
        public void Destroy () {
            Destroy(gameObject);
            OnDestroyed.Invoke(this);
            OnDestroyed.RemoveAllListeners();
        }
    }
    
    
