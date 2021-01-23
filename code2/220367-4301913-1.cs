    static void Main (string[] args)
    {
        foreach (var arg in args)
        {
            var arr = arg.Split(':');
            if (arr.Length == 2)
            {
                string name = arr[0];
                string value = arr[1];
                // parse arg as a key-value pair
            }
            else
            {
                // parse arg as a flag
            }
        }
    }
