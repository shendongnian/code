    public class Example : MonoBehaviour
    {
        public UnityEvent OnSomethingHappened;
        // And invoke it where needed
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) OnSomethingHappened?.Invoke();
        }
    }
