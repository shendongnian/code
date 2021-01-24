    public class CustomButtom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public enum ButtonState
        {
            Normal,
            Hover,
            Pressed,
            Disabled
        }
    
        public UnityEvent onClick;
    
        private bool _isDisabled;
        public bool IsDisabled
        {
            get => _isDisabed;
            set
            {
                SetState(value ?ButtonState.Disabled : ButtonState.Normal);
            }
        }
    
        public void OnPointerEnter (PointerInputEvent eventData)
        {
            if(_isDisabled) return;
    
            SetState(ButtonState.Hover);
        }
    
        public void OnPointerExit (PointerInputEvent eventData)
        {
            if(_isDisabled) return;
    
            SetState(ButtonState.Normal);
        }
    
        public void OnPointerDown (PointerInputEvent eventData)
        {
            if(_isDisabled) return;
    
            SetState(ButtonState.Pressed);
    
            onClick.Invoke();
        }
    
        public void OnPointerUp(PointerInputEvent eventData)
        {
             If(_isDisabled) return;
            SetState(ButtonState.Normal);
        }
    
        private void SetState(ButtonState state)
        {
            // TODO: handle states to change styles etc as feedback
            _isDisabled = state == ButtonState.Disabled;
        }
    }
