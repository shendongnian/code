    using System.Linq;
    ...
    // will store all buttons except B and LeftShift
    KeyCode[] otherKeys;
    private void Awake ()
    {
        // This simply returns an array with all values of KeyCode
        var allKeys = (KeyCode[])Enum.GetValues(typeof(KeyCode));
        // This uses Linq Where in order to only keep entries that are different from
        // KeyCode.B and KeyCode.LeftShift
        // ToArray finally converts the IEnumerable<KeyCode> into a KeyCode[]
        otherKeys = allKeys.Where(k => k != KeyCode.B && k != KeyCode.LeftShift).ToArray();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.B) && !AnyOtherKeyPressed())
        {
            // Happens while ONLY LeftShift + B is pressed
        }
    }
    // Return true if any other key
    // is pressed except B and LeftShift
    private bool AnyOtherKeyPressed()
    {
        foreach (var keyCode in otherKeys)
        {
            if(Input.GetKey(keyCode)) return true;
        }
        return false;
    }
