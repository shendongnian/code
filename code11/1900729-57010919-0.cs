    if (Swipe.Instance.Tap && !isGameStarted)
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        { 
            isGameStarted = false;
        }
        else
        {
              isGameStarted = true;
              motor.StartRunning();
              gameCanvas.SetTrigger("Show");
        }
    }
