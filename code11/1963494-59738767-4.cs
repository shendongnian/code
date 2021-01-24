    public TouchDetector : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData data)
        {
            Debug.Log("I was touched!", this);
            GetComponemt<Renderer>().material.color = Color.Red; 
        }
    }
