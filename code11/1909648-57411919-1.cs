    public class Example : MonoBehaviour
    {
        [Selection] public string MySelection;
    
        private void Start()
        {
            Debug.Log(MySelection);
        }
    }
