    public static bool CameraPresent1()
    {
        return ((bool)Microsoft.WindowsMobile.Status.SystemState.CameraPresent)
              && ((bool)Microsoft.WindowsMobile.Status.SystemState.CameraEnabled);
    }
