    // Add your texts in the editor or by calling texts.Add(someNewString)
    public List<string> texts = new List<string>();
    
    private int index = 0;
    
    if(Input.GetKeyDown(KeyCode.Space)) 
    {
        if(texts.Count > index) say(texts[index]);
        index++;
    }
