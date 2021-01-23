    int totalCount = result.Count();
    for (int count = 0; count < totalCount; count++)
    {
        Item result = Model.Results[count];
        count++;
        // do something with each item
        if (count == totalCount)
        {
            // do something different with the last item
        }
        else
        {
            // do something different with every item but the last
        }
    }
