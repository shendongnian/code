    public void Test()
    {
        var inputArray = new[] { 2, 1, 5, 6, 8, 1, 8, 6, 2, 9, 2, 9, 1, 2 };
        var queryArray = new[] { 6, 1, 2 };
        var result = SmallestWindow(inputArray, queryArray);
        if (result == null)
        {
            Console.WriteLine("no matching window");
        }
        else
        {
            Console.WriteLine("Smallest window is indexes " + result[0] + " to " + result[1]);
        }
    }
