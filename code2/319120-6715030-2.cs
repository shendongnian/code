    public static List<int> Test2(List<int> arrayInput)
    {
        for (int i = 0; i < arrayInput.Count - 2; i++)
        {
            if (arrayInput[i + 2] == arrayInput[i + 1] + 1
            && arrayInput[i + 2] == arrayInput[i] + 2)
            {
                arrayInput.RemoveAt(i + 2);
                arrayInput.RemoveAt(i);
                i = Math.Max(-1, i - 3); // -1 'cause i++ in loop will increment it
            }
        }
        return arrayInput;
    }
