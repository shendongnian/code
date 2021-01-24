    var pointerEventData = new pointerEventData{ position = touchPos};
    var raycastResults = new List<RaycastResult>();
    EventSystem.current.RaycastAll(pointerEventData, raycastResults);
    if(raycastResults.Count > 0)
    {
        foreach(var result in RaycastResults)
        {
            ...
        }
    }
