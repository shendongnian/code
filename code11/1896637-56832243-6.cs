    public string[] texts;
    private int index = 0;
    
    if(Input.GetKeyDown(KeyCode.Space)) 
    {
        // have a safety check if the counter is still within 
        // valid index values
        if(texts.Length > index) say(texts[index]);
        // increase index by 1
        index++;
    }
