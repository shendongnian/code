    private void HandleMessage(string message)
    {
        var splittedStrings = message.Split(' ');
        if (splittedStrings.Length != 3) return;
        // Here you probably wanted to use the correct indices!
        var x = float.Parse(splittedStrings[0]);
        var y = float.Parse(splittedStrings[1]);
        var z = float.Parse(splittedStrings[2]);
        
        // start a routine for smooth movement over time
        // either using a constant speed (units/second)
        StartCoroutine(MoveWithConstantSpeed(targetPos, 1f));
        // or with a dynamic velocity but a fixed duration (seconds)
        StartCoroutine(MoveWithConstantSpeed(targetPos, 1f));
    }
    // optional (but recommneded) a flag for skipping new movement 
    // until the last one is finished
    private bool isMoving;
    private IEnumerator MoveInFixedDuration(Vector3 targetPos, float speed)
    {
        // ignore if already moving to avoid concurrent routine
        if(isMoving) yield break;
        isMoving = true;
        while(Vector3.Distance(transform.position, targetPos) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            // pause this routine, render the frame and continue from here
            // in the next frame
            yield return null;
        }
        isMoving = false;
    }
    private IEnumerator MoveInFixedDuration(Vector3 targetPos, float duration)
    {
        // ignore if already moving to avoid concurrent routine
        if(isMoving) yield break;
        isMoving = true;
        var startPos = transform.position;
        var timePassed = 0f;
        while(timePassed < duration)
        {
            var factor = timePassed / duration;
            // optionally add ease-in and ease-out
            factor = Mathf.SmoothStep(0, 1, factor);
            transform.position = Vector3.Lerp(startPos, endPos, factor);
            // increase by time passed since last frame, using Mathf.Min to avoid overshooting
            timePassed += Mathf.Min(Time.deltaTime, duration - timePassed);
            // pause this routine, render the frame and continue from here
            // in the next frame
            yield return null;
        }
        isMoving = false;
    }
