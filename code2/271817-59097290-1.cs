    int BoolArrayToInt(bool[] bArray)
    {
        char[] caseChar = new char[bArray.Length];
        for(int i = 0; i < bArray.Length; i++)
        {
            if (bArray[i] == true)
            {
                caseChar[i] = '1';
            }
            else
            {
                caseChar[i] = '0';
            }
        }
        string caseString = new string(caseChar);
        int caseNum = System.Convert.ToInt32(caseString);
        return caseNum;
    }
