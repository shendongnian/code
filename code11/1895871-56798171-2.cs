    using System.Collections;
    //...
    private void Start()
    {
        StartCoroutine(RunTimer());
    }
    
    private IEnumerator RunTimer()
    {
        var time = 0f;
        uiText.text = "Time: " + time.ToString("#.0##");
        // looks scary but is okey in a coroutine as long as you yield somewhere inside
        while(true)
        {
            // yield return makes the routine pause here
            // allow Unity to render this frame
            // and continue from here in the next frame
            //
            // WaitForSeconds .. does what the name says
            yield return new WaitForSeconds(0.01f);
            time += 0.01f;
            uiText.text = "Time: " + time.ToString("#.0##");
        }
    }
