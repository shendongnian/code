    static public int addTwoEach(int[] args)
    {
        int sum = 0;
        foreach (var item in args)
        {
            sum += item + 2;
        }
        return sum;
    }
    addtwoEach(); // throws an error
