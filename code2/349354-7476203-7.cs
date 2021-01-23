    int totalCount = result.Count();
    for (int count = 0; count < totalCount; count++)
    {
        Item result = Model.Results[count];
        //count++; // Correction: Commented, incrementing second time would introduce bug in loop iterations. Rather do (count + 1) inside if statement
        // do something with each item
        if ((count + 1) == totalCount)
        {
            // do something different with the last item
        }
        else
        {
            // do something different with every item but the last
        }
    }
