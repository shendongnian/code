    public static int[] MoveZeroes(int[] arr)
    {
        // TODO: Program me
        int zeroCount = 0;
        var temp = new List<int>();
        int numberItems = 0;
        foreach (var a in arr)
        {
            if (a == 0)
            {
                zeroCount += 1;
            }
            else
            {
                temp.Add(a);
            }
            numberItems += 1;
        }
        return temp.ToArray();
    }
