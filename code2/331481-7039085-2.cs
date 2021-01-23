    …
    for (int i = 0; i < splitString1.Length; i++)
    {
        int partComparisonResult = String.Compare(splitString1[i], splitString2[i]);
        if (partComparisonResult == 0)
        {              // these two parts are identical,
            continue;  // so move on to the next position.
        }              // (this clause is superfluous, but included for clarity.)
        else
        {              // these parts differ, so return their sort order:
            return partComparisonResult;
        }
    }
