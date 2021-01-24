    [RequireComponent((typeof(Button)))]
    public class DownUpButtonEnhancement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        private Button _button;
    
        public UnityEvent OnButtonDown;
        public UnityEvent OnButtonUp;
    
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
    
        //Detect current clicks on the GameObject (the one with the script attached)
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            if (!_button.interactable) return;
    
            OnButtonDown?.Invoke();
        }
    
        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            OnButtonUp?.Invoke();
        }
    
        // Detect if pointer leaves the object
        public void OnPointerExit(PointerEventData eventData)
        {
            // additionally reset if pointer leaves button while pressed
            OnButtonUp?.Invoke();
        }
    }
    
