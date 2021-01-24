    using UnityEngine;
    using UnityEngine.EventSystems;
    public class YourButton : MonoBehavior, IPointerEnterHandler, IPointerClickHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Raycast hit!");
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked!");
        }
    }
