    [RequireComponent(typeof(Text))]
    public class TextButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region Inspector
        public Color NormalColor = Color.black;
        public Color HoverColor = Color.black;
        public Color PressColor = Color.black;
        public Color DisabledColor = Color.gray;
    
        // add calbacks in the inspector like for buttons
        public UnityEvent onClick;
        #endregion Inspector
    
        private bool _isInteractive = true;
        public bool interactive
        {
            get
            { 
                return _isInteractive; 
            }
            set
            {
                _isInteractive = value;
                UpdateColor();
            }
        }
    
        private bool _isPressed;
        private bool _isHover;
    
        private Text _textComponent;
        private Text TextComponent
        {
            get
            {
                if(!_textComponent) _textComponent = GetComponent<Text>() ?? gameObject.AddComponent<Text>();
                
            }
        }
        private void Updatecolor()
        {
            if (!interactive)
            {
                TextComponent.color = DisabledColor;
                return;
            }
    
            if (isPressed)
            {
                TextComponent.color = PressColor;
                return;
            }
    
            if (isHover)
            {
                TextComponent.color = HoverColor;
                return;
            }
    
            TextComponent.color = NormalColor;
        }
   
        #region IPointer Callbacks
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!", this);
    
            // invoke your event
            onClick.Invoke();
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
           if(!_isHover)return;
            _isPressed = true;
            Updatecolor();
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
          if(!_isHover)return;
            _isPressed = false;
            Updatecolor();
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            _isHover = true;
            Updatecolor();
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            _isHover = false;
            _isPressed = false;
            Updatecolor();
        }
        #endregion IPointer Callbacks
    }
