    bool isDragging;
    
    private void Update()
    {
        if(!Input.GetMouseButtonDown(0) || isDragging) return;
    
        ...
    
    }
    
    private IEnumerator DragObject()
    {
        isDragging = true;
    
        ...
        while(!Input.GetMouseButtonDown(0))
        {
            ...
        }
        ...
    
        isDragging = false;
    }
