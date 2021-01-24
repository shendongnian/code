    using System.Linq;
    ...
    // will store all buttons except B and LeftShift
    KeyCode[] otherKeys;
    private void Awake ()
    {
        otherKeys = (KeyCode[])Enum.GetValues(typeof(KeyCode)).Where(k => k != KeyCode.B && k != KeyCode.LeftShift).ToArray();
    }
    // Return true if any other button 
    // is pressed except B and LeftShift
    private bool AnyOtherButtonPressed()
    {
        foreach (var keyCode in otherKeys)
        {
            if(Input.GetKey(keyCode)) return true;
        }
        return false;
    }
