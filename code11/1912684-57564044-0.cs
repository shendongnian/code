    public async Task A(int id, Delegate b)
    {
        try
        {
            await BeforeAsync(id);
            if (b.DynamicInvoke(id) is Task task) await task;
            await AfterAsync(id);
        }
        catch (Exception ex)
        {
            Handle(ex, id);
        }
    }
