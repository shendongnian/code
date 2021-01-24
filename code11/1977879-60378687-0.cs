    void Start()
    {
        checkboxes = GetComponentsInChildren<Toggle>().ToList();
        foreach(Toggle toggle in checkboxes) {
            // get an initial count of on/off
            if(toggle.isOn) {
                TogglesOn++;
            } else
            {
                TogglesOff--;
                unCheckedBoxes.Add(toggle,"");
            }
 
            // listen for changes
            toggle.onValueChanged.AddListener((value)=>OnToggleValueChanged(toggle));
        }
    }
    private void OnToggleValueChanged(Toggle toggle)
    {
        bool isOn = toggle.isOn;
        TogglesOn += isOn ? 1 : -1;
        if (isOn)
        {
            checkedBoxes.Add(toggle, "");
            unCheckedBoxes.Remove(toggle);
        }
        else
        {
            checkedBoxes.Remove(toggle);
            unCheckedBoxes.Add(toggle, "");
        }
        if (TogglesOn >= 2)
        {
            foreach (KeyValuePair<Toggle, String> tempToggle in unCheckedBoxes)
            {
                tempToggle.Key.enabled = false;
            }
        }
        else
        {
            foreach (KeyValuePair<Toggle, String> tempToggle in unCheckedBoxes)
            {
                tempToggle.Key.enabled = true;
            }
        }
    }
