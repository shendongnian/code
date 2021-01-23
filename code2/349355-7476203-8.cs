    Item last = Model.Results.Last();
    foreach (Item result in Model.Results)
    {
        // do something with each item
        if (result.Equals(last))
        {
            // do something different with the last item
        }
        else
        {
            // do something different with every item but the last
        }
    }
