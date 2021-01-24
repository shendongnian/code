    // Makes sure only one scrolling process is running at a time
    private bool isScrolling;
    private IEnumerator MoveTo(Vector3 targetPosition)
    {
        if (isScrolling) yield break;
        isScrolling = true;
        while (containerTransform.position != targetPosition)
        {
            containerTransform.position = Vector3.MoveTowards(containerTransform.position, endPosition, speed * Time.deltaTime);
            yield return null;
        }
        isScrolling = false;
        print("Swipe ends");
    }
