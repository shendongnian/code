    using UnityEngine;
    
    public class FullScreenMode : MonoBehaviour
    {
        // Don't forget to drag the ScreenManager instance to this reference in the inspector
        [Serializable]
        ScreenManager _screenManager;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                // Change the Toggle UI since this was triggered with F11
                _screenManager.ToggleFullScreen(true);
            }
        }
    }
