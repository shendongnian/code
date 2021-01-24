    foreach (var number in TestList)
    {
        if(!actionBlock.Post(number))
            actionBlock.Complete();
        try
        {
            await actionBlock.Completion;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            //actionBlock is now dead
            break;
        }
    }
