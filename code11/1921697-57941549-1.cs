    public class PlayerMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        [SerializeField]
        private Button targetButton;
    
        [SerializeField, Tooltip("The targeted player's movement component")]
        private Move2D playerMovement;
    
        [SerializeField, Tooltip("True if this button moves the player to the left")]
        private bool movesLeft;
    
        // ...
    
        public void OnPointerDown(PointerEventData eventData) {
            if (movesLeft) {
                playerMovement.TriggerMoveLeft();
            } else {
                playerMovement.TriggerMoveRight();
            }
        }
    
        public void OnPointerUp(PointerEventData eventData) {
            if (movesLeft) {
                playerMovement.TriggerMoveRight();
            } else {
                playerMovement.TriggerMoveLeft();
            }
        }
    }
