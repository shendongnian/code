    try
    {
        RECORD rec; // ie, your entity definition of a record (row)
        Object[] onePK = { id, s0, s1 };
        rec = YourEntities.RECORDs.Find(onePK);
        if (rec == null)
        {
            // handle the record-not-found situation
        }
    }
    catch (SystemException sex)
    {
        string error = sex.Message;
    }
  
