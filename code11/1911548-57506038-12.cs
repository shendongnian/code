    // inherits from MonoBehaviour -> already implements the full functionality
    // of MonoBehaviors
    public abstract class AnAwesomeBehaviour : MonoBehaviour
    {
        // it can have some fields all inheritors shall have
        // everyone will have access to this
        public string Horse;
        // only this class and inheritors will have access to this
        protected int amountOfHorses;
        // only this class has access to this
        private Camera _camera;
        // The same can be done for methods
        // But there are now special methods
        // a virtual method already has its own implementation
        // but can be overwritten or extended by inheritors
        protected virtual void Start()
        {
            _camera = Camera.main;
            Debug.Log("On Start I usually do nothing special with the " + _camera.name);
        } 
        // an abstract method kind of works like an interface
        // every inheritor HAS TO implement this method exactly with the same 
        // signature
        public abstract void DoYourThing(string value);
        // and you still can implement some default behaviours that every
        // inheritor will just do
        private void Update()
        {
            // rotate the object forever
            transform.Rotate(0, Time.deltaTime * 45, 0);
        }
    }
