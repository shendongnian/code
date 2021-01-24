    string finalNumbers = GetStartNumbers(myListOfNumbers, 18);
    if(finalNumbers.EndsWith(" ... "))
        finalNumbers += GetEndNumbers(myListOfNumbers, 2);
    
    
    public string GetStartNumbers(string listOfNumbers, int collectThisManyNumbers) 
    {
        int spaceCounter = 0;    //  The current count of spaces
        int charPointer = 0;     //  The current character in the string
        //  Loop through the list of numbers until we either run out of characters
        //  or get to the appropriate 'space' position...
        while(spaceCounter < collectThisManyNumbers && charPointer <= listOfNumbers.Length)
        {
            //  The following line will add 1 to spaceCounter if the character at the
            //  charPointer position is a space. The charPointer is then incremented...
            spaceCounter += ( listOfNumbers[charPointer++]==' ' ? 1 : 0 );
        }
        //  Now return our value based on the last value of charPointer. Note that
        //  if our string doesn't have the right number of elements, then it will
        //  not be suffixed with ' ... '
        if(spaceCounter < collectThisManyNumbers) 
            return listOfNumbers.Substring(0, charPointer - 1);
        else
            return listOfNumbers.Substring(0, charPointer - 1) + " ... ";
    }
    
    public string GetEndNumbers(string listOfNumbers, int collectThisManyNumbers) 
    {
        int spaceCounter = 0;                       //  The current count of spaces
        int charPointer = listOfNumbers.Length;     //  The current character in the string
        //  Loop through the list of numbers until we either run out of characters
        //  or get to the appropriate 'space' position...
        while(spaceCounter < collectThisManyNumbers && charPointer >= 0)
        {
            //  The following line will add 1 to spaceCounter if the character at the
            //  charPointer position is a space. The charPointer is then decremented...
            spaceCounter += ( listOfNumbers[charPointer--]==' ' ? 1 : 0 );
        }
        //  Now return our value based on the last value of charPointer...
        return listOfNumbers.Substring(charPointer);
    }
