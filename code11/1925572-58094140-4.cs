    public class ReleaseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public UnityEvent onPointerUp;
    
        [SerializeField] private Button button;
        private void Awake()
        {
            if(!button) button = GetComponent<Button>();
        }
        // according to the Docs this has to be implemented in order to
        // receive OnPointerUp events ... though we don'T need it actually
        public void OnPointerDown(PointerEventData pointerEventData){ }
        public void OnPointerExit(PointerEventData pointerEventData)
        {
            if(!button.interactable) return;
            onPointerUp.Invoke();
        }
    
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            if(!button.interactable) return;
            onPointerUp.Invoke();
        }
    }
