    // Attach this to gameobject and your classes will show up on inspector
    public class A : MonoBehaviour
    {
        // both B and C is class
        public B b;
        public C[] c;
        
    }
    
    //This doesn't need to be monobehaviour 
    [System.Serializable]
    public class C : MonoBehaviour {
    
    	
    }
    // Same goes for this you can remove monobehaviour
    [System.Serializable]
    public class B : MonoBehaviour {
    
    	
    }
