    private bool isSwiping;
    
    public IEnumerator MoveForward()
    {
        if(isSwiping)
        {
            Debug.LogWarning("Already swiping -> ignored", this);
            yield break;
        }
        isSwiping = true;
        
        //...
        
        isSwiping = false;
    }
