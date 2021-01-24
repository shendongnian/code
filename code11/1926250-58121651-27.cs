    public class KeysManager : MonoBehaviour
    {
        public static bool ShiftPressed;
        public static HashSet<KeyCode> currentlyPressedKeys = new HashSet<KeyCode>();
    
        private void OnGUI()
        {
            if (!Event.current.isKey) return;
            if (Event.current.keyCode != KeyCode.None)
            {
                if (Event.current.type == EventType.KeyDown)
                {
                    currentlyPressedKeys.Add(Event.current.keyCode);
                }
                else if (Event.current.type == EventType.KeyUp)
                {
                    currentlyPressedKeys.Remove(Event.current.keyCode);
                }
            }
            ShiftPressed = Event.current.shift;
        }
    }
