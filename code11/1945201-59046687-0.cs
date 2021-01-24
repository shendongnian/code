    void LogGazeDirectionOrigin()
    {
        Debug.Log("Position at which the gaze hit an object: "
            + CoreServices.InputSystem.GazeProvider.HitInfo.point);
        Debug.Log("Gaze is looking in direction: "
            + CoreServices.InputSystem.GazeProvider.GazeDirection);
    Debug.Log("Gaze origin is: "
            + CoreServices.InputSystem.GazeProvider.GazeOrigin);
    }
     
