    [RequireComponent(typeof(Text))]
    public class TextButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Color NormalColor = Color.black;
        public Color HoverColor = Color.black;
        public Color PressColor = Color.black;
        public Color DisabledColor = Color.gray;
    
        // add calbacks in the inspector like for buttons
        public UnityEvent onClick;
    
        public bool interactive = true;
    
        private bool isPressed;
    
    
        private bool isHover;
    
        private void Updatecolor()
        {
            if (!interactive)
            {
                _textComponent.color = DisabledColor;
                return;
            }
    
            if (isPressed)
            {
                _textComponent.color = PressColor;
                return;
            }
    
            if (isHover)
            {
                _textComponent.color = HoverColor;
                return;
            }
    
            _textComponent.color = NormalColor;
        }
    
        private Text _textComponent;
    
        private void Awake()
        {
            _textComponent = GetComponent<Text>();
        }
    
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!", this);
    
            // invoke your event
            onClick.Invoke();
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
           if(!isHover)return;
            isPressed = true;
            Updatecolor();
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
          if(!isHover)return;
            isPressed = false;
            Updatecolor();
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            isHover = true;
            Updatecolor();
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            isHover = false;
            isPressed = false;
            Updatecolor();
        }
    }
