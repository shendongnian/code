    public class A : MonoBehaviour
    {
        public UnityEvent OnSomethingHappened = new UnityEvent();
        private void SomeMethodIWillRun()
        {
            //...
            OnSomethingHappened.Invoke();
        }
    }
