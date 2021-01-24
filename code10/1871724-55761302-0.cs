    private void Start()
    {
        myDropdown.onValueChanged.RemoveListener(HandleValueChanged);
        myDropdown.onValueChanged.AddListener(HandleValueChanged);
    }
    private void OnDestroy()
    {
        myDropdown.onValueChanged.RemoveListener(HandleValueChanged);
    }
    private void HandleValueChanged(Dropdown dropdown)
    {
          switch (dropdown.value)
        {
            case 1:
                Debug.Log("Basic panel!");
                modalPanelObject.SetActive(true);
                modalPanelObjectAdvance.SetActive(false);
                break;
            case 2:
                Debug.Log("Advance panel!");
                modalPanelObjectAdvance.SetActive(true);
                modalPanelObject.SetActive(false);
                break;
        }
    }
