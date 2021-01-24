    private void Update()
    {
        Debug.Log("Update frame count: " + Time.frameCount);
    }
    
    private void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick frame count: " + Time.frameCount);
    }
