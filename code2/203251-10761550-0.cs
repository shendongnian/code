    int numDataTypes = allData.Select(o => o.Type).Distinct().Count();
    IEnumerable<TableModel> ByTypes = allData
                  .GroupBy(o => o.Type)
                  .Select((g, index) => new TableModel()
                  {
                    ...
                    IsLastItem = index == (numDataTypes - 1),
                  });
