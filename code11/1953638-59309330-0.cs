		// check if there are filters in the worksheet.
		if (workbookWorksheet.AutoFilter == null ||
			workbookWorksheet.AutoFilter.Filters.Count == 0)
		{
			// no filters
			return;
		}
		// go over the filters and get the addresses
		for (var i = 1; i < ws.AutoFilter.Filters.Count; i++)
		{
			var filter = ws.AutoFilter.Filters[i];
            Console.WriteLine(filter.On); // print/check if the filter is on.
			Range range = ws.AutoFilter.Range[1, i];
			Console.WriteLine(range.Address); // address of the filter cell
		}
