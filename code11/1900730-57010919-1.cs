    if (Swipe.Instance.Tap && !isGameStarted)
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        { 
            isGameStarted = false;
            return;
        }
        
        isGameStarted = true;
        motor.StartRunning();
        gameCanvas.SetTrigger("Show");
    }
