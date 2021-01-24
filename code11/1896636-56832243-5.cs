    // Add your texts in the editor or by calling texts.Add(someNewString)
    public List<string> texts = new List<string>();
    
    private int index = 0;
    
    if(Input.GetKeyDown(KeyCode.Space)) 
    {
        // have a safety check if the counter is still within 
        // valid index values
        if(texts.Count > index) say(texts[index]);
        // increase index by 1
        index++;
    }
