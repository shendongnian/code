    public class UiPointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            PlayerInput.DisableInput();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            PlayerInput.EnableInput();
        }
    }  
