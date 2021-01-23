    public static bool IsOnlyNumbers(string strValidateString, bool boolCheck4LetterOrDigit)
    {
        bool boolValidatePassed = false;
        switch (boolCheck4LetterOrDigit)
        {
          case  true:
            {
                if (strValidateString.All(Char.IsDigit))
                {
                    boolValidatePassed = true;
                }
                break;
            }
          case false:
            {
                if (strValidateString.All(Char.IsLetter))
                {
                    boolValidatePassed = false;
                }
                break;
            }
        }
        return boolValidatePassed;
    }
