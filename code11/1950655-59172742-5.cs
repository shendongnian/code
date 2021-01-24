    public class ExampleInMainScene
    {
        [Header("Debug")]
        [SerializeField] private GameObject startPanel;
        private void Awake()
        {
            // Try to get the reference
            startPanel = GlobalReferences.StartPanel;
            // if this failed then wait until it is ready
            if(!startPanel)
            {
                // it is save to remove callbacks even if not added yet
                // makes sure a listener is always only added once
                GlobalReferences.OnStartPanelReady -= OnStartPanelReady;
                GlobalReferences.OnStartPanelReady += OnStartPanelReady;
            }
            // otherwise already do what you want
            else
            {
                OnStartPanelReady(startPanel);
            }
        }
        private void OnDestroy()
        {
            // always make sure to clean up callbacks when not needed anymore!
            GlobalReferences.OnStartPanelReady -= OnStartPanelReady;
        }
        private void OnStartPanelReady(GameObject newStartPanel)
        {
            startPanel = newStartPanel;
            // always make sure to clean up callbacks when not needed anymore!
            GlobalReferences.OnStartPanelReady -= OnStartPanelReady;
            // NOTE: It is possible that at this point it is null anyway if another
            // class has set this actively to null ;)
            if(startPanel)
            {
                // Now do something with the startPanel
            }
        }
    }
