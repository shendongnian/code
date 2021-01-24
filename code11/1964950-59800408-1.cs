    int Nearest(int value, int[] arr)
    {
        var distances = arr.Select(x => Math.Abs(x - value)).ToList();
        int min = distances.Min();
        // Using LastIndexOf is important 
        // if you get two equal distances (I.E. 48/50 and passing 49)
        return arr[distances.LastIndexOf(min)];
    }
