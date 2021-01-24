    void Update()
    {
        if (shouldLerp)
        {
            transform.position = Lerp(startPosition, endPosittion, timeStartedLerping, lerpTime);
            // I'm not 100% sure how lerpTime is supposed to be used,
            // but I'm guessing it's something like this.
            // Either way, this value needs to be updated somehow.
            lerpTime += Time.time;
        }
    }
