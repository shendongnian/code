    using UnityEngine.EventSystems;
    using UnityEngine;
    
    public class MouseOverHandler: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
       public void OnPointerEnter(PointerEventData data){
            Debug.Log("MouseEnter");
       }
       public void OnPointerExit(PointerEventData data){
            Debug.Log("MouseExit");
       }
    }
