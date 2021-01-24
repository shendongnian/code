    public class MoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public enum Alignment
        {
            Global,
            Local
        }
        // Configure here the movement step per second in all three axis
        public Vector3 moveStep;
        // Configure here wether you want the movement in
        // - Global = World-Space
        // - Local = Object's Local-Space
        public Alignment align;
        private Button button;
        private void Awake ()
        {
            button = GetComponent<Button>();
        }
        //Detect current clicks on the GameObject (the one with the script attached)
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            // Ignore if button is disabled
            if(!button.interactible) return;
            StartCoroutine (Move());
        }
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            StopAllCoroutines();
        }
        public void OnPointerExit(PointerEventData pointerEventData)
        {
            StopAllCoroutines();
        }
        // Actually not really needed but I'm not sure right now
        // if it is required for OnPointerExit to work
        // E.g. PointerDown doesn't work if PointerUp is not present as well
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
        
        }
        // And finally to the movement
        private IEnumerator Move()
        {
            // Whut? Looks dangerous but is ok as long as you yield somewhere
            while(true)
            {
                Depending on the alignment move one step in the given direction and speed/second
                if(align == Alignment.Global)
                {
                    transform.position += moveStep * Time.deltaTime;
                }
                else
                {
                    transform.localPosition += moveStep * Time.deltaTime;
                }
                // Very important! This tells the routine to "pause"
                // render this frame and continue from here
                // in the next frame.
                // without this Unity freezes so careful ;)
                yield return null;
            }
        }
    }
