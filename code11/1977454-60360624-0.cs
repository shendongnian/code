    string userInput = stringInput.Text;
    string userSentence = userInput.ToLower();
    string encryptedSentence = "";
    
    foreach (char letter in userSentence)
    {
        var morseChar = morseCodeTable.FirstOrDefault(x => x.Key == letter.ToString()).Value ?? " / ";
        encryptedSentence += morseChar;
    }
    
    stringInput.Text = encryptedSentence;
