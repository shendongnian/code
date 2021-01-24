    public static bool DetectAndRemoveCharacter(ref string Word, char Character)
    {
        bool returnVal = false;
        for (int x = 0; x < Word.Length; x++)
        {
            if (Word[x] == Character)
            {
                // assign value here
                Word = Word.Remove(x, 1);
                returnVal = true;
                break;
            }
        }
        return returnVal;
    }
