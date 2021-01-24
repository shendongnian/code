    var designEnum= Designs.AsEnumerable();
    var firstSelect = designEnum.Where(row => values.Contains(row.Field<Guid>("DesignGroupId"));
    var secondSelect = firstSelect.Where(row => row.Field<int>("DesignKey") == null);
    if (secondSelect.Count == 0)
    {
        //Handle the fact that you have no data
        design = null;
    }
    else
    {
        designs = secondSelect.CopyToDataTable();
    }
