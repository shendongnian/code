    public static Dictionary<char,double> sampleData = new Dictionary<char, double>
    {
    	['a'] = 0.5
    };
    
    public int WheelofFortune(string secretWord, char letterGuess, int pointValue)
    {
    	int sum = 0;
    
    	for (int i = 0; i < secretWord.Length; i++)
    		if(sampleData.ContainsKey(secretWord[i]))
    			sum += (int)(pointValue * sampleData[letterGuess]);
    		
    	return sum;
    }
