    public void OnPointerDown(PointerEventData eventData)
    {
        fingersOnButton++;
        if (fingersOnButton == 1)
        {
            if (movesLeft)
            {
                playerMovement.TriggerMoveLeft();
            }
            else
            {
                playerMovement.TriggerMoveRight();
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        fingersOnButton--;
        if (fingersOnButton == 0)
        {
            if (movesLeft)
            {
                playerMovement.StopMoveLeft();
            } else
            {
                playerMovement.StopMoveRight();
            }
        }
    }
