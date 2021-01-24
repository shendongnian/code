    public void DoDisplay(string _displayMessage)
    {
        StartCoroutine(DoDisplayRoutine(_displayMessage));
    }
    private IEnumerator DoDisplayRoutine(string _displayMessage) 
    {
        // Activate Panel
        DisplayPanel.SetActive(true);
        // Set flag and display message
        _isComplete = false;
        Message_Text.text = _displayMessage;
        Debug.Log("Waiting");
        yield return new WaitUntil(() => _isComplete);
        // OR if you really want to display the log every frame meanwhile
        while(!_isComplete)
        {
            Debug.Log("Waiting");
            // render this frame and continue from here in the next one
            // If you missed to yield return somewhere in a while loop
            // then yes, this would also freeze the main thread
            yield return null;
        }
        //Clear and close
        Message_Text.text = "";
        DisplayPanel.SetActive(false);
    }
    // A simple Button press to clear the flag
    public void OnComplete() 
    {
        _isComplete = true;
    }
