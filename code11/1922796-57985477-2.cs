    public void DoDisplay(string _displayMessage) 
    {
        // Activate Panel
        DisplayPanel.SetActive(true);
        // display message
        Message_Text.text = _displayMessage;
        // log only once
        Debug.Log("Waiting");
    }
    // A simple Button press to clear the flag
    public void OnComplete() 
    {
        //Clear and close
        Message_Text.text = "";
        DisplayPanel.SetActive(false);
    }
    
