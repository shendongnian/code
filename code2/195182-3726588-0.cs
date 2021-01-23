    var Input = txtQuestion.text; // Implicitly typed variable of type string
    listview1.itemsource = getinput(Input); 
    
    // Strongly typed method taking string, returning List<answers> 
    public List<answers>getinput(string question) 
    { 
        var result = new List<answers>();
        result.Add(answer);
        return result; 
    } 
