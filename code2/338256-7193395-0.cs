    for (int i = 0; i < myIntCollection.Count; i++)
    {
        if (myIntCollection[i] == 42)
        {
            myIntCollection.Remove(i);
            i--;
        }
    }
