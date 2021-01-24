    DataTable dt;
    try
    {
        switch (foo)
        {
            case bar:
                dt = BLL.GetDataTable(bar);
                break;
            default:
                dt = BLL.GetDataTable();
                break;
        }
    }
    finally
    {
        dt?.Dispose();
    }
