    [RequireComponent(typeof(Button))]
    public class PlayASound : MonoBehaviour
    {
        // reference via inspector
        [SerializeField] private AudioSelector _audioSelector;
    
        // your enum type here
        public AudioMessageType MessageType;
    
        public void Play()
        {
            _audioSelector.PublishAudioMesssage(MessageType);
        }
    
        private Button _button;
    
        private void Awake()
        {
             _button = GetComponent<Button>();
    
            if (!_button)
            {
                Debug.LogError("No Button found on this GameObject!", this);
                return;
            }
    
            _button.onClick.AddListener(Play);
        }
    
        // Just to to be sure
        // usually the button should be destroyed along with this component
        // anyway ... but you never know ;)
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Play);
        }
    }
    
