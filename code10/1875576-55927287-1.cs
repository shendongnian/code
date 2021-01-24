    static async Task Main(string[] args)
    {
        LogNewOrders();
        DataTable initialData = ControllerSqlAgent.SelectQuery(Resources.Controller, Resources.qryGetInitalData);
        Console.WriteLine($"|There are {initialData.Rows.Count} orders to check|");
        await UpdateItemCountsField(initialData);
    }
