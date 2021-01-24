    namespace ANamespace
    {
        public class A : MonoBehaviour { 
    
            private void Awake()
            {
                // it is save to remove a callback first even 
                // if it was not added yet. This makes sure it is
                // added only once always
                AEventHandler.OnIvokeA -= SomePrivateMethod;
                AEventHandler.OnIvokeA += SomePrivateMethod;
            }
    
            private void OnDestroy()
            {
                AEventHandler.OnIvokeA -= SomePrivateMethod;
            }
    
            private void SomePrivateMethod()
            {
                // magic
            }
      
        }  
    }
    
