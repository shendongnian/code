    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.DoMove(!movesLeft);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.StopMove();
    }
