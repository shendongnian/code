    interface ITimeMulti
    {
        DateTime DateTimeUtc { get; set; }
        float Source { get; set; }
        // will be used for number of available properties.
    	int MultCount { get; } 
        // the main method for generating the multipliers. 
    	void Generate(int multNumber, int multiplier); 
    }
