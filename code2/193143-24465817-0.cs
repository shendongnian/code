        var line = "someStringToSwapCase";
        var charArr = new char[line.Length];
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] >= 65 && line[i] <= 90)
            {
                charArr[i] = (char)(line[i] + 32);
            }
            else if (line[i] >= 97 && line[i] <= 122)
            {
                charArr[i] = (char)(line[i] - 32);
            }
            else
            {
                charArr[i] = line[i];
            }
        }
        var res = new String(charArr);
