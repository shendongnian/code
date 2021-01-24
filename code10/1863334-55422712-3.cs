    int[] A = new int[20];
    Random rnd = new Random();
    int index;
    // repeat
    do
    {
        // select a random singer (by his index)
        index = rnd.Next(0, A.Length);
        // add one vote for this singer
        A[index]++;
    }
    // until one singer has 1000 votes
    while(A[index] < 1000)
