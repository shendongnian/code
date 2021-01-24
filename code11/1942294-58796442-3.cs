    [RequireComponent(typeof(UI.Button))]
    public class DataServiceButton : MonoBehaviour
    {
        public enum ButtonType
        {
            Save,
            Load
        }
    
        // This is set via the Inspector
        [SerializeField] private ButtonType type;
    
        // Here you can already reference the according Button component
        [SerializeField] private Button button;
    
        private void Awake()
        {
            if(!button) button = GetComponent<Button>();
    
            // Register as callback
            button.onClick.AddListener(HandleClick);
        }
    
        private void HandleClick()
        {
            switch(type)
            {
                case ButtonType.Load:
                    DataService.LoadGameData();
                    // OR IF YOU STICK TO THE SINGLETON
                    //DataService.Instance.LoadGameData();
                    break;
                case ButtonType.Save:
                    DataService.SaveGameData();
                    // OR ACCORDINGLY WITH SINGLETON
                    //DataService.Instance.SaveGameData();
                    break;
            }
        }
    }
