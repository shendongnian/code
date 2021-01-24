    textToSend.onValueChanged.AddListener(delegate { OnValueChangesInputField(); })
    
    public void OnValueChangesInputField()
    {
       //Dynamic Text, get the string as it is being types
       string dynamicText = textToSend.text;
    }
