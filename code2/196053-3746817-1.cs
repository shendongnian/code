    public void Test()
    {
        var inputArray = new[] { 2, 5, 2, 8, 0, 1, 4, 7 };
        var queryArray = new[] { 2, 1, 7 };
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
