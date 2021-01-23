    var query = _summaryTable.AsEnumerable()
         .Where(
             summaryRows => summaryRows.Field<string>("AirlineDisplayName")
                 .Equals(airlineName_, StringComparison.OrdinalIgnoreCase));
    if (condition)
        query = query.OrderBy(summaryRows => summaryRows.Field<decimal>("FareAdult"));
    else
        query = query.OrderBy(summaryRows => summaryRows.Field<double>("BasePricePlusTaxAndFees"));
    var resultQuery = query.Select(summaryRows => new
        {
            summaryTableRow = summaryRows
        });
