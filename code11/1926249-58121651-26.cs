    public HashSet<KeyCode> currentlyPressedKeys = new HashSet<KeyCode>();
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
        // Shift is actually the only Key which is not treated as a
        // EventType.KeyDown or EventType.KeyUp so it has to be checked separately
        // You will not be able to check which of the shift keys is pressed!
        if (!Event.current.shift)
        {
            return;
        }
        // As said shift is check on another way so we want only 
        // exactly 1 key which is KeyCode.B
        if (currentlyPressedKeys.Count == 1 && currentlyPressedKeys.Contains(KeyCode.B))
            Debug.Log("Only Shift + B");
    }
