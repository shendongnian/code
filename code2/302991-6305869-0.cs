    bool finished = false;
    int i = 0;
    oldCount = genericListInstanceB.Count;
    while (!finished)
    {
        var ItemA = genericListInstanceB[i];
        ItemA.MethodThatCouldRemoveAnyItemInGenericListInstanceB();
        if (genericListInstanceB.Count == oldCount)
           i++;
        else
        {
           if (genericListInstanceB.IndexOf(ItemA) == i)
               i++;
           // All other outcomes result in us leaving i alone
           oldCount = genericListInstanceB.Count;
        }
        finished = (i > (oldCount - 1));
    }
