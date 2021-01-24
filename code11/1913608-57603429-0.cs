    public abstract class Agent : MonoBehaviour
    {
        private void Start(){
            // Your code needed for all inheriting classes here.
         
            // Call the abstract method which is defined on inheriting classes
            OnStarting();
        }
        
        protected abstract void OnStarting();
    }
    
    public class Enemy : Agent
    {
        protected override OnStarting()
        {
            // Your enemy code here.
        }
    }
    
    public class WalkerEnemy : Enemy 
    {
        protected override OnStarting()
        {
            // Your enemy code here.
        }
    }
