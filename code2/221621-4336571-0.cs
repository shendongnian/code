    int max = reader.MaxDoc();
    for (int iDoc = 0; iDoc < max; iDoc++)
    {
      if (!reader.IsDeleted(iDoc))
      {
         Document doc = reader.Document(iDoc);
         // read fields
      }
    }
