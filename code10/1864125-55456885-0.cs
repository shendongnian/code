    public void LetterToBox() {
        int rowCount = 0;
        int position = 0;
        foreach (string word in phraseToSplitToWords.Split(" ")) {
            if (CannotFitWordWithoutCuttingPastTheLimit(position,word, whateverIsTheNumberOfLettersPerLineYouWant)) {
                rowCont++;
                position= 0;
            }
            PlaceTheWordLetterByLetterInThisPosition(position,row,word);
            position = position + word.Length +1; //+1 for the space between words
        }
    }
    public void PlaceTheWordLetterByLetterInThisPosition(int positionInLine, int row, string word) {
        foreach (char letter in word) {
            var x = positionInLine* LETTER_WIDTH;
            var y = row* LETTER_HEIGHT;
            InstantiateLetter(x, y, letter); //basically the same way you did
            
        }
    }
 
    public bool CannotFitWordWithoutCuttingPastTheLimit(int position, string word, int limit) {
        return (position + word.Length > limit);
    }
   
