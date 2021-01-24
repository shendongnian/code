    public static string[] check_word_for_lingo(string guess, string secret_word)
    {
        String[] checks = new string[5];
        char[] remainingLettersToCheck = secret_word.ToCharArray();
        char[] secretWordLetters = secret_word.ToCharArray();
        for (int a=0; a<5; a++)
        {
            if (guess[a]==secret_word[a])
            {
                checks[a] = "0"; remainingLettersToCheck[a] = ' ';
            } else {
                checks[a] = " ";
            }
        }
        secret_word = new string(remainingLettersToCheck);
        for (int a = 0; a < 5; a++)
        {
            if (remainingLettersToCheck[a] != ' ')
            {
                if (guess[a] != ' ' && secret_word.Contains(guess[a]))
                {
                    checks[a] = "1"; remainingLettersToCheck[a] = ' ';
                }
                else
                {
                    checks[a] = "2";
                }
            }
        }
        return checks;
    }
