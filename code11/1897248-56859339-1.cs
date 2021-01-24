    // create a linq version of the table
    var lqTable = new LinqTable(dt);
    // make the group by query
    var groupByNames = lqTable.Rows.GroupBy(row => row["LastName"].ToString() + "-" + row["FirstName"].ToString()).ToList();
    // for each group create a brand new linqRow
    var linqRows = groupByNames.Select(grp =>
    {
        //get all items. so we can use first item for last and first name and sum the age easily at the same time
        var items = grp.ToList();
        // return a new linq row
        return new LinqRow()
        {
            Fields = new List<LinqField>()
                {
                    new LinqField("LastName",items[0]["LastName"].ToString()),
                    new LinqField("FirstName",items[0]["FirstName"].ToString()),
                    new LinqField("Age",items.Sum(item => Convert.ToInt32(item["Age"]))),
                }
        };
    }).ToList();
    // create new linq Table since it handle the datatable format ad transform it directly
    var finalTable = new LinqTable() { Rows = linqRows }.AsDataTable();
