    // Add your texts in the editor
    public List<string> texts = new List<string>();
    
    private int index = 0;
    
    if(Input.GetKeyDown(KeyCode.Space)) 
    {
        if(texts.Count > index) say(texts[index]);
        index++;
    }
