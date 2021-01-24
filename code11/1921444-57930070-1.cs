    public class ContinuesButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Button button;
    
        [SerializeField] private UnityEvent whilePressed;
    
        private bool isHover;
    
        private void Awake()
        {
            if(!button) button = GetComponent<Button>();
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(WhilePressed());
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            StopAllCoroutines();
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
        }
    
        private IEnumerator WhilePressed()
        {
            while(true)
            {
                whilePressed?.Invoke();
                yield return null;
            }
        }
    }
    
