    public class B : MonoBehaviour
    {
        public A referenceToA;
        private void Start()
        {
            referenceToA.OnSomethingHappened.AddCallback(OnASomethingHappened);
        }
        private void OnDestroy()
        {
            referenceToA.OnSomethingHappened.RemoveCallback(OnASomethingHappened)
        }
        private void OnASomethingHappened()
        {
            //
        }
    }
    
