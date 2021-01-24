    public class ExampleInNewScene
    {
        // already reference it via the Inspector
        [SerializeField] private GameObject startPanel;
    
        private void Awake()
        {
            // as a fallback
            if(!startPanel) startPanel = GameObject.FindObjectWithTag("startPanel");
    
            // assign it to the global class
            GlobalReferences.startPanel = startPanel;
        }
    }
    
