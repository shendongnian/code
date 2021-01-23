    byte startDelimit = 23;
    byte endDelimit = 11;
    List<ICollection<byte>> result = new List<ICollection<byte>>();
    int lastMatchingPosition = 0;
    var inputAsList = input.ToList();
    for(int i = 0; i <= inputAsList.Count; i++)
    {
        if(inputAsList[i] == startDelimit && inputAsList[i + 1] == endDelimit)
        {
            ICollection<byte> temp = new ICollection<byte>();
            for(int j = lastInputPosition; j <= i ; j++)
            {
                temp.Add(inputAsList[j]);
            }
            result.Add(temp);
            lastMatchingPosition = i + 2;
        }
    }
