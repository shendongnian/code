    static void PrintArray(double[] aArray)
    {
        var str = "";
        for (int index = 0; index < aArray.Length; index++)
        {
            var item = aArray[index];
            str += item.ToString();
            if (index < aArray.Length - 1)
                str += ", ";
        }
        Console.WriteLine("[" + str + "]");
    }
