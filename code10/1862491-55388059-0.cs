    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            gameObject.transform.position = Input.mousePosition;
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log("OnEndDrag");
        }
    }
