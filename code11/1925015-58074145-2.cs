    // Attach this to gameobject and your classes will show up on inspector
    public class A : MonoBehaviour
    {
        // both B and C is class
        public B b;
        public C[] c;
        
    }
    
    //This doesn't need to be monobehaviour as this should be the data class and A should be the container
    [System.Serializable]
    public class C {
        public int number;
    	
    }
    // Same goes for this you can remove monobehaviour
    [System.Serializable]
    public class B {
       [SerializeField]
        private int ID;
    	public string name;
        
    }
