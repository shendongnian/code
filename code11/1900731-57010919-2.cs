    if (Swipe.Instance.Tap && !isGameStarted)
    {
        foreach(var touch in Input.touches)
        {
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            { 
                isGameStarted = false;
                return;
            }
        }
        
        isGameStarted = true;
        motor.StartRunning();
        gameCanvas.SetTrigger("Show");
    }
