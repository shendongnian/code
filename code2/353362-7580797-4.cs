    static public int addTwoEach(params int[] args)
    {
        int sum = 0;
        foreach (var item in args)
        {
            sum += item + 2;
        }
        return sum;
    }
    addtwoEach(); // returns 0
