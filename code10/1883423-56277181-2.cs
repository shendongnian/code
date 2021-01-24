    public static async Task CustomAsyncMethod(int id, Data data)
    {
        //  ...
        var first = await data.GetHistoryById(id);
        var second = await data.GetOtherByName(first.Name);
 
        // ...
    }
