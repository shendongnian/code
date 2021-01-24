    [Serializable]
    public class KeyCombo
    {
        // Note I'll be lazy here .. you could create a custom editor 
        // for making sure each keyCode is unique .. but another time
        public List<KeyCode> keyCodes = new List<KeyCode>();
        // This will show an event in the Inspector so you can add callbacks to your keyCombos
        // this is the same thing used in e.g. Button onClick
        public UnityEvent whilePressed;
        // Here all other keyCodes will be stored
        [HideInInspector] public KeyCode[] otherKeys;
        // Return true if any other key
        // is pressed except B and LeftShift
        public bool AnyOtherKeyPressed()
        {
            foreach (var keyCode in otherKeys)
            {
                if (Input.GetKey(keyCode)) return true;
            }
            return false;
        }
    }
    public List<KeyCombo> keyCombos = new List<KeyCombo>();
    private void Awake()
    {
        // This simply returns an array with all values of KeyCode
        var allKeys = (KeyCode[])Enum.GetValues(typeof(KeyCode));
        foreach (var keyCombo in keyCombos)
        {
            // This uses Linq Where in order to only keep entries that are different from
            // the ones listed in keyCodes
            // ToArray finally converts the IEnumerable<KeyCode> into a KeyCode[]
            keyCombo.otherKeys = allKeys.Where(k => !keyCombo.keyCodes.Contains(k)).ToArray();
        }
    }
    private void Update()
    {
        foreach (var keyCombo in keyCombos)
        {
            if (keyCombo.keyCodes.All(Input.GetKey) && !keyCombo.AnyOtherKeyPressed())
            {
                keyCombo.whilePressed.Invoke();
            }
        }
    }
