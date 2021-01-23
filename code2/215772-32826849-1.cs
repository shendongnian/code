    internal bool SearchWord(string str, string searchKey)
    {
        int j = 0; bool result = false;
        for (int i = 0; i < str.Length; i++)
        {
            if (searchKey[j] == str[i])
            {
                j++; //count++;
            }
            else { j = 0; }
            if (j == searchKey.Length)
            {
                result = true;
                break;
            }
        }
        return result;
    }
