    using UnityEngine;
    
    public class FullScreenMode : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F11))
                ScreenManager.ToggleFullScreen();
        }
    }
