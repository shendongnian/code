        string EnglishNumbers="";
        for (int i = 0; i < arabicnumbers.Length; i++)
        {
            EnglishNumbers += char.GetNumericValue(arabicnumbers, i);
        }
        int convertednumber=Convert.ToInt32(EnglishNumbers);
