    int[] tmp = new int[myIntCollection.Count ()];
    myIntCollection.CopyTo(tmp);
    foreach(int i in tmp)
    {
        myIntCollection.Remove(42); //The error is no longer here.
    }
