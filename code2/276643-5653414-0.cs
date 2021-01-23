    // Warning, this code only works for characters inside the BMP. (Surrogate code points will need special care.)
    string text = myTextBox.Text;
    int hanCharacterCount = 0;
    foreach (char c in text)
        if (lowestHanCodepoint <= c && c <= highestHanCodepoint)
            hanCharacterCount++;
    double hannessScore = (double)hanCharacterCount / text.Length;
