    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LevelTextAssigner : MonoBehaviour
    {
        // you can reference this already in the Inspector
        // then you don't need to use GetComponent
        [SerializeField] private TextMeshProUGUI _text;
        
        // Is called before sceneLoaded is called
        private void Awake()
        {
            if(!_text) _text = GetComponent<TextMeshProUGUI>();
            // It is possible that the first time GameSession.Instance is not set yet
            // We can ignore that because in this case the reference still exists anyway
            if(GameSession.Instance)
            {
                GameSession.Instance.YourFirstScript.leveltext = _text;
            }
        }
    }
