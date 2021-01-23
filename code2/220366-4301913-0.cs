    static void Main (string[] args)
    {
        foreach (var arg in args)
        {
            var arr = arg.Split(':');
            if (arr.Lenght == 2)
            {
                arg = arr[0]; // arg name
                string value = arr[1]; // arg value
                // parse arg as a key-value pair
            }
            else
            {
                // parse arg as a flag
            }
        }
    }
