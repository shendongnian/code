    public class AttackDamage : MonoBehaviour 
    {
            // Start is called before the first frame update
            void Start()
            {
        
            }
        
            
            public void Method1()
            {
              // Do Something like Attack++;
            } 
    }
        
    public class ADButton : MonoBehaviour 
    {           
            public AttackDamage obj;
            // Start is called before the first frame update
            void Start()
            {
              obj.Method1();
            }
        
          
    }
