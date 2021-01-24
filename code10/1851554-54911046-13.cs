    public float swipeDuration;
    private IEnumerator MoveTo(Vector3 targetPosition)
    {
        if (isScrolling) yield break;
        isScrolling = true;
        var currentPosition = containerTransform.position;
        var timePassed = 0.0f;
        while (timePassed < swipeDuration)
        {
            var lerpFactor = timePassed / swipeDuration;
            containerTransform.position = Vector3.Lerp(currentPosition, endPosition, lerpFactor);
            yield return null;
        }
        // To be sure set a fixed end position
        containerTransform.position = endPosition;
        isScrolling = false;
        print("Swipe ends");
    }
