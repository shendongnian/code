    var array = new int[]{ 1, 3, 5, 7, 9, 11, 13, 15, 17, 19};
            
    var result = IsGreaterThanTen(array[0]);
    for (int i = 1; i < array.Length; i++)
    {
        var number = array[i];
        if (number % 2 == 0)
        {
            result = result && IsGreaterThanTen(number);
        }
        else
        {
            result = result || IsGreaterThanTen(number);
        }
    }
    return result;
