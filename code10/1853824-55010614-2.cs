    using UnityEngine;
    
    public class ScreenManager : MonoBehaviour
    {
        Toggle onOffSwitch;
    
        void Start()
        {
            // Don't forget to attach the Toggle component to this game object
            onOffSwitch = GetComponent<Toggle>(); 
            
            // Subscribe to onOffSwitch's onValueChanged event handler
            onOffSwitch.onValueChanged.AddListener(delegate 
            {
                // delegate method to call when onOffSwitch.onValueChanged is raised.
                ToggleValueChanged(onOffSwitch); 
            });
        }
        
        public static void ToggleFullScreen(bool updateToggleUI)
        { 
            var toggledValue = !Screen.fullScreen;
            Screen.fullScreen = toggledValue;
            onOffSwitch.isOn = updateToggleUI ? toggledValue : onOffSwitch.isOn;
        }
        
        void ToggleValueChanged(Toggle change)
        {
            // The toggle was already changed via the UI, don't flip it back
            ToggleFullScreen(false); 
        }
    }
