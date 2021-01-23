      var a = from Page in rowData
        group Page by new { 
        S1 = Page.PartitionKey.Substring(0,2),
        S2 = Page.PartitionKey.Substring(2,6),
        S3 = Page.PartitionKey.Substring(8)
        } into group
        select new {
        group.key.S1
        , group.key.S2
        , group.Key.S3
        , total = rowData.sum(s => s.Page)
    };
