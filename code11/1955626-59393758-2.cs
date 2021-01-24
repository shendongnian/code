    // in seconds
    public float duration = 1;
    private bool isDoingLine;
    private void Start()
    {
        // Add a Line Renderer to the GameObject
         line = GetComponent<LineRenderer>();
         // Set the width of the Line Renderer
         line.SetWidth(0.0012F, 0.0012F);
         line.positionCount = 2;
         line.SetPosition(0, gameObject1.transform.position);
         line.SetPosition(1, gameObject1.transform.position);
         DoLine();
    }
    public void DoLine()
    {
        if(!isDoingLine) StartCoroutine(LineRoutine());
    }
    IEnumerator LineRoutine() 
    {
         isDoingLine = true;
         line.SetPosition(0, gameObject1.transform.position);
         var timePassed = 0f;
         while(timePassed < duration)
         {
             var factor = timePassed / duration;
             // optionally add ease-in ease-out
             //factor = Mathf.SmoothStep(0, 1, factor);
             line.SetPosition(1, Vector3.Lerp(gameObject1.transform.position, gameObject2.transform.position, factor));
             timePassed += Mathf.Min(Time.deltaTime, duration - timePassed);
             yield return null;
         }
         // when done just in case set the final position fix
         line.SetPosition(1, gameObject2.transform.position);
         isDoingLine = false;
     }
