using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class CameraController : MonoBehaviour
{
    private bool lightOn = false;
    private bool frontCamera = false;
    public void CameraChange()
    {
        if (!frontCamera)
        {
            RestartCamera(CameraDevice.CameraDirection.CAMERA_FRONT);
            frontCamera = true;
            Debug.Log("Using Front Camera");
        }
        else if (frontCamera)
        {
            RestartCamera(CameraDevice.CameraDirection.CAMERA_BACK);
            frontCamera = false;
            Debug.Log("Using Back Camera");
        }
        else
        {
            Debug.Log("No camera status available.");
        }
    }
    private void RestartCamera(CameraDevice.CameraDirection newDir)
    {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Deinit();
        CameraDevice.Instance.Init(newDir);
        CameraDevice.Instance.Start();
        // Periodically check to see if still needed
        VuforiaUnity.OnPause();
        VuforiaUnity.OnResume();
    }
}
