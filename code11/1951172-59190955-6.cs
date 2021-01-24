    // flag for preventing concurrent routines
    private bool isBlinking;
    private Renderer[] colorCable;
    private void Awake()
    {
        // you want to do this only once!
        colorCable = CableStrip.GetComponentsInChildren<Renderer>(true);
    }
    private void Update()
    {
         // is the condition fulfilled?
         if(camManager.transform.position == camPosition)
         {
             if(!isBlinking) StartCoroutine(BlinkRoutine());
         }
         else
         {
             StopAllCoroutines();
             isBlinking = false;
         }
    }
    private IEnumerator BlinkRoutine()
    {
         isBlinking = true;
         var blinkObject = false;
         // this looks scary but is fine in a Coroutine
         // as long as you YIELD somewhere inside!
         while(true)
         {
             blinkObject = !blinkObject;
             foreach (var cableChild in colorCable)
             {
                 // Shorthand for if(blinkObject) { ... = yellow; } else { ... = white; }
                 cableChild.material = blinkObject ? yellow : white;
             }
             yield return new WaitForSeconds(1);
         }
    }
