    bool finished = false;
    int i = 0;
    oldCount = genericListInstanceB.Count;
    while (!finished)
    {
        var itemA = genericListInstanceB[i];
        itemA.MethodThatCouldRemoveAnyItemInGenericListInstanceB();
        if (genericListInstanceB[i] == itemA)
            i++;
            // All other outcomes result in us leaving i alone
        oldCount = genericListInstanceB.Count;
        finished = (i > (oldCount - 1));
    }
