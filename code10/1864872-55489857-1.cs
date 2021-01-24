    public class MyClickable : MonoBehaviour, IPointerClickHandler
    {
        public float distanceThreshold;
        public Transofrm playerTransform;
        // this gives you an event you can configure in the Inspector
        // exactly like you would with a button
        public UnityEvent onClick;
        private bool isInRange;
        public void OnPointerClick(PointerEventData pointerEventData)
        {
            // if too far away do nothing
            if(Vector3.Distance(playerTransform.position, transform.position) > distanceThreshold) return;
            ....
            
            onClick.Invoke();
        }
        private void Update()
        {
            if(Vector3.Distance(playerTransform.position, transform.position) <= distanceThreshold)
            {
                // e.g. make object green
            }
            else
            {
                // e.g. make object grey
            }
        }
    }
