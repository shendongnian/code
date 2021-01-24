    using UnityEngine;
    
    public static class ScreenManager : MonoBehaviour
    {
        public static void ToggleFullScreen()
        { 
            Screen.fullScreen = !Screen.fullScreen
        }
    }
