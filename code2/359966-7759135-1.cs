    using (FbDataReader DBReader = FBC.ExecuteReader())
    {
        using (var iterator = DBReader.GetEnumerator())
        {
            while (true)
            {
                DbDataRecord record = null;
                try
                {
                    if (!iterator.MoveNext())
                    {
                        break;
                    }
                    record = iterator.Current;
                }
                catch (FbException e)
                {
                    // Handle however you want to handle it
                }
                yield return record;
            }
        }
    }
