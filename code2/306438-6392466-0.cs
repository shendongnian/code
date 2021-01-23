    public string Base64Encode (Int64 Number)
    {
        string HelpString = "";
        if (Number >= 64)
        {
            HelpString = Base64Encode(Number / 64);
        }
        return (HelpString += Base64EncodeHelper(Number % 64));
    }
    
    public string Base64EncodeHelper(Int64 Number)
    {
        string HelpString = "";
        Number += 65;
        if ((Number >= 65 && Number <= 90) || (Number >= 97 && Number <= 122))  // 0 - 25 and 32 - 57
        {
            HelpString = Convert.ToString((char)Number);
        }
        else if (Number >= 91 && Number <= 96)                                  // 26 - 31
        {
            HelpString = Convert.ToString((char)(Number - 43));
        }
        else if (Number >= 123 && Number <= 126)                                // 58 - 61
        {
            HelpString = Convert.ToString((char)(Number - 69));
        }
        else if (Number == 127)                                                 // 62
        {
            HelpString = "-";
        }
        else                                                                    // 63
        {
            HelpString = "_";
        }
        return (HelpString);
    }
    
    public Int64 Base64Decode(string Encoded)
    {
        Int64 Result = 0, HelpInt = 0;
        int i = Encoded.Length - 1;
        foreach (char Character in Encoded)
        {
            int CharInInt = (int)Character;
            if (Character == '_')
            {
                HelpInt = 63;
            }
            else if (Character == '-')
            {
                HelpInt = 62;
            }
            else if (((CharInInt + 69) >= 123) && ((CharInInt + 69) <= 126))
            {
                HelpInt = CharInInt + 4;
            }
                else if (((CharInInt + 43) >= 91) && ((CharInInt + 43) <= 96))
            {
                HelpInt = CharInInt - 22;
            }
            else
            {
                 HelpInt = CharInInt - 65;
            }
            Result += Convert.ToInt64((Math.Pow(64, Convert.ToDouble(i))) * HelpInt);
            i--;
        }
        return Result;
    }
