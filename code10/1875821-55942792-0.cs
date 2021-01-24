    var actionBlock = new ActionBlock<int>(item =>
    {
        try
        {
            if (item == 5)
                throw new Exception("Blech.");
            Debug.WriteLine(item.ToString());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    });
