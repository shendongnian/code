    string theSentence = "I really want you to shut the door.";
    string thePhrase = "Shut The Door";
    bool phraseIsPresent = theSentence.ToUpper().Contains(thePhrase.ToUpper());
    int phraseStartsAt = theSentence.IndexOf(
        thePhrase, 
        StringComparison.InvariantCultureIgnoreCase);
    Console.WriteLine("Is the phrase present? " + phraseIsPresent);
    Console.WriteLine("The phrase starts at character: " + phraseStartsAt);
