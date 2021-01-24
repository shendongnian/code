    public class WhilePressedRotation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform target;
        private void Start ()
        {
            if(!target) target = GameObject.Find("Globe");
        }
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            StartCoroutine(RotateContinuously());
        }
    
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            StopAllCoroutines();
        }
    
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            // Actually not really needed
            // but not sure if maybe required for having OnPointerExit work
        }
    
        public void OnPointerExit(PointerEventData pointerEventData)
        {
            StopAllCoroutines();
        }
        private IEnumerator RotateContinuously()
        {
            // Whut? o.O
            // No worries, this is fine in a Coroutine as long as you yield somewhere inside
            while (true)
            {
                // You should use Find only once .. if at all. You should avoid it wherever possible!
                if(!target) target = transform.Find("Globe");
                smooth = Time.deltaTime * smoothTime * convertedTime;
                target.Rotate(rotationDirection * smooth);
                // Very important for not freezing the editor completely!
                // This tells unity to "pause" the routine here
                // render the current frame and continue
                // from this point on the next frame
                yield return null;
            }
        }
    }
