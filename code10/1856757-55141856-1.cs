    public class TextButton : MonoBehaviour, IPointerClickHandler
    {
        // add calbacks in the inspector like for buttons
        public UnityEvent onClick;
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Clicked!");
            // invoke your event
            onClick.Invoke();
        }
    }
    
