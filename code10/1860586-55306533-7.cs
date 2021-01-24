    foreach (var item in table.AsEnumerable())
    {
        // item is a DataRow here
        var myString = item.Field<string>("tag");     // gets string
        // you can also do
        var myInt = item.Field<int>("Id");            // gets int
        var myDate = item.Field<DateTime>("Date");    // gets DateTime
        var myValue = item.Field<decimal>("Price");   // gets decimal
    }
