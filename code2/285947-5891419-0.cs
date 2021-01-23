    string orig = "ABD";
    int[] oneBasedIndices = new [] { 2, 3, 1 };
    string copy = orig;
    for ( int i = 0; i < orig.Length; i++ )
    {
        orig[i] = copy[ oneBasedIndices[i] - 1 ];
    }
