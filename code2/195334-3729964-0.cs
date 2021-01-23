    private unsafe static string SwitchSplitOnComma2(string text)
    {
        int comma = text.IndexOf(',');
        string newString = string.Copy(text);
        fixed (char* src = text)
        {
            fixed (char* dst = newString)
            {
                int destCtr = 0;
                for (int i = comma + 1; i < text.Length; i++)
                {
                    dst[destCtr++] = src[i];
                }
                dst[destCtr++] = ',';
                for (int i = 0; i < comma; i++)
                {
                    dst[destCtr++] = src[i];
                }
            }
        }
        return newString;
    }
