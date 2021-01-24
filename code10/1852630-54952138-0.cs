    private static List<string> Divide(List<string> input, int index, int partitions)
    {
        var stringToDivide = input[index];
        input.RemoveAt(index);
        var stringToAdd = "";
        var partitionLength = stringToDivide.Length / partitions;
        for (int i = 0, partitionNum = 0; i < stringToDivide.Length; i++)
        {
            if (i % partitionLength == 0 && partitionNum != partitions)
            {
                stringToAdd += " ";
                partitionNum++;
            }
            stringToAdd += stringToDivide[i];
        }
        
        input.Insert(index, stringToAdd.Trim());
        
        return input;
    }
