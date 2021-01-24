    [RequireComponent((typeof(Button)))]
    public class ContinousButtonEnhancement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button _button;
    
        // will get fired every frame while button stays pressed
        public UnityEvent WhilePressed;
    
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
    
        //Detect current clicks on the GameObject (the one with the script attached)
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            if (!_button.interactable) return;
    
            StartCoroutine(FireRepeatedly());
        }
    
        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            StopAllCoroutines();
        }
    
        private IEnumerator FireRepeatedly()
        {
            while (true)
            {
                // Invoke the event -> execute all added listeners
                WhilePressed?.Invoke();
    
                // This makes the routine "stop" here
                // allow Unity to render the frame
                // and continous from here in the next frame
                yield return null;
            }
        }
    }
    
