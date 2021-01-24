    private void Start()
    {
        // Just to be sure it is allways only added once
        // I have the habit to remove before adding a listener
        // This is valid even if the listener was not added yet
        myDropdown.onValueChanged.RemoveListener(HandleValueChanged);
        myDropdown.onValueChanged.AddListener(HandleValueChanged);
    }
    private void OnDestroy()
    {
        // To avoid errors also remove listeners as soon as they
        // are not needed anymore
        // Otherwise in the case this object is destroyed but the dropdown is not
        // it would still try to call your listener -> Exception
        myDropdown.onValueChanged.RemoveListener(HandleValueChanged);
    }
    private void HandleValueChanged()
    {
        switch (myDropdown.value)
        {
            case 0:
                Debug.Log("Basic panel!");
                modalPanelObject.SetActive(true);
                modalPanelObjectAdvance.SetActive(false);
                break;
            case 1:
                Debug.Log("Advance panel!");
                modalPanelObjectAdvance.SetActive(true);
                modalPanelObject.SetActive(false);
                break;
        }
    }
