    [System.ComponentModel.DataObjectMethodAttribute
        (System.ComponentModel.DataObjectMethodType.Select, false)]
    public Scout.ScoutDataTable GetItems(string node, int rank1, int rank2)
    {
        ScoutTableAdapter Adapter = new ScoutTableAdapter();
        Adapter.SetCommandTimeout(60);
        return Adapter.GetDataBy(node, rank1, rank2);
    }
