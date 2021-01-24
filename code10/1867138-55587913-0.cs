    private bool ReadersContainEqualData(OracleDataReaders readerA, OracleDataReaders readerB)
    {
        bool moreResultsA = false;
        bool moreResultsB = false;
        do {
            if(readerA.FieldCount != readerB.FieldCount)
            {
                return false; // the readers have different number of columns
            }
            while(readerA.Read() && readerB.Read())
            {
                for(int i = 0; i < readerA.FieldCount; i++)
                {
                    if(readerA.GetName(i) != readerB.GetName(i)) // different column names, remove this check if it is not important to you
                    {
                       return false;
                    }
                    if(readerA[i] != readerB[i]) // the columns are either string, numeric or booean, so simple equals comparison works. If more complex columns like varbinary etc is used, this check will need to be enhanced
                    {
                        return false;
                    }
               }
            }
            if(readerA.Read() || readerB.Read()) // one of the readers still has more rows and the other is empty
            {
                return false;
            }
            // check if the readers contains results from another query than the recently processed
            moreResultsA = readerA.NextResult();
            moreResultsB = readerB.NextResult();
            if(moreResultsA != moreResultsB)
            {
                return false;
            }
        } while(moreResultsA && moreResultsB);
        return true;
    }
