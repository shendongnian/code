    int ixNew = 0;
    int ixOld = 0;
    while (ixNew < NewList.Count && ixOld < OldList.Count)
    {
        // Again with the comparison delegate.
        // I'll assume that MyRecord implements IComparable
        int cmpRslt = OldList[ixOld].CompareTo(NewList[ixOld]);
        if (cmpRslt == 0)
        {
            // records have the same customer id.
            // compare for changes.
            ++ixNew;
            ++ixOld;
        }
        else if (cmpRslt < 0)
        {
            // this old record is not in the new file.  It's been deleted.
            ++ixOld;
        }
        else
        {
            // this new record is not in the old file.  It was added.
            ++ixNew;
        }
    }
    // At this point, one of the lists might still have items.
    while (ixNew < NewList.Count)
    {
        // NewList[ixNew] is an added record
        ++ixNew;
    }
    while (ixOld < OldList.Count)
    {
        // OldList[ixOld] is a deleted record
    }
