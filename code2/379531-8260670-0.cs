    int[] x = new int[] { 1, 2, 1, 2, 4, 3, 2 };
    Dictionary<int, int> counts = new Dictoinary<int, int>();
    foreach( int a in x ) {
        if ( counts.ConatinsKey(a) )
            counts[a] = counts[a]+1
        else
            counts[a] = 1
    }
    int result = int.MinValue;
    int max = int.MinValue;
    foreach (int key in counts.Keys) {
        if (counts[key] > result)
            max = counts[key];
            result = key;
    }
    Console.WriteLine("The mode is: " + result);
