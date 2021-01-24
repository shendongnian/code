    public static bool isTimerMoving = false;
    public void Update()
    {
        if (speed < 0.5f)
        {
            t = t + Time.deltaTime;
            isTimerMoving = true;
        }
        else if (isTimerMoving) {
            t = 0;
            isTimerMoving = false;
        }
    }
