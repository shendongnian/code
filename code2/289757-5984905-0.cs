    string UserFormat = "SssEee";
    string EpisodeNumber = "0105";
    
    int ifmt = 0;
    int iepi = 0;
    int season = 0;
    int episode = 0;
    
    while (ifmt <= UserFormat.Length && iepi < EpisodeNumber.Length)
    {
        if ((UserFormat[ifmt] == "S" || UserFormat[ifmt] == "E"))
        {
            if (EpisodeNumber[iepi] == UserFormat[ifmt])
            {
                ++iepi;
            }
            else if (!char.IsDigit(EpisodeNumber[iepi]))
            {
                // Error! Chars didn't match, and it wasn't a digit.
                break;
            }
            ++ifmt;
        }
        else
        {
            char c = EpisodeNumber[iepi];
            if (!char.IsDigit(c))
            {
                // error. Expected digit.
            }
            if (UserFormat[ifmt] == 'e')
            {
                episode = (episode * 10) + (int)c - (int)'0';
            }
            else if (UserFormat[ifmt] == 's')
            {
                season = (season * 10) + (int)c - (int)'0';
            }
            else
            {
                // user format is broken
                break;
            }
            ++iepi;
            ++ifmt;
        }
    }
