    public class clickshake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        //Detect current clicks on the GameObject (the one with the script attached)
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            transform.localScale -= new Vector3(0.1F, 0.1f, 0);
        }
    
        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            transform.localScale += new Vector3(0.1F, 0.1f, 0);
        }
    }
