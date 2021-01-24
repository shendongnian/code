    public class Parent
    {
        public virtual void OnTriggerEnter()
        {
            UnityEngine.Debug.Log("Message From Parent");
        }
    }
    
    public class Child : Parent
    {
        public override void OnTriggerEnter()
        {
            //base.OnTriggerEnter();
            UnityEngine.Debug.Log("Message From Child");
        }
    }
    
    public class Test
    {
        public void TestRunner()
        {
            Parent parent = new Child();
            parent.OnTriggerEnter(); // output Message From Child.
        }
    }
