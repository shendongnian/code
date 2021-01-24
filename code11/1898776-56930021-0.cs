    //something along these lines:
    using UnityEngine;
    public class DestroyOnClick : Monobehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerClickEventData data)
        {
            Destroy(this.gameObject);
        }
    }
