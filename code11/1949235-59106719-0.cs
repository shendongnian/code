    void Main()
    {
    
    	string mySentence = "myy senttence";
    	IsRepeating(mySentence, 't'); //return True
    	IsRepeating(mySentence, 'y'); //return True
    	IsRepeating(mySentence, 'e'); //return False
    }
    
    public bool IsRepeating(string sequence, char character)
    {
    	return Regex.IsMatch(sequence, character + "{2,}");
    }
