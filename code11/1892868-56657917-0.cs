    public class LanguageMenu : MonoBehaviour
    {
        private Task _task;
        private async void Awake()
        {
            _task = Localization.Initialize();
            await _task;
        }
        private void Start()
        {
            await _task;
            Debug.Log(Localization.Available.Count);
        }
        private void Update()
        {
        }
    }
