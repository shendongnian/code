    ...
    if (!dictionary1.ContainsKey(row1["value1"].ToString().Trim()))
    {
        dictionary1.Add(row1["value1"].ToString().Trim(), GetNumbersArray());
    }
    if (!dictionary2.ContainsKey(row1["value2"].ToString().Trim()))
    {
         dictionary2.Add(row1["value2"].ToString().Trim(), GetNumbersArray());
    }
    ...
    private int[] GetNumbersArray()
    {
        int[] numbers = new int[3];
        numbers[0] = 0;
        numbers[1] = 0;
        numbers[2] = 0;
        return numbers;
    }
