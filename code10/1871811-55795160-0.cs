    var search = new FolderSearchAdvanced()
    {
        criteria = new FolderSearch()
        {
            basic = new FolderSearchBasic()
            {
                internalId = new SearchMultiSelectField()
                {
                    @operator = SearchMultiSelectFieldOperator.anyOf,
                    searchValue = new[] { searchValue },
                    operatorSpecified = true
                },
            }
        },
        columns = new FolderSearchRow
        {
            basic = new FolderSearchRowBasic()
            {
                internalId = new[] { new SearchColumnSelectField() },
                name = new [] { new SearchColumnStringField() }
            },
            fileJoin = new FileSearchRowBasic()
            {
                internalId = new[] { new SearchColumnSelectField() },
                name = new[] { new SearchColumnStringField() },
                modified = new[] { new SearchColumnDateField() },
                documentSize = new[] { new SearchColumnLongField() }
            }
        }
    };
    var results = ns.search(search);
    if (results.status.isSuccess)
    {
        foreach (var result in results.searchRowList)
        {
            if (result is FolderSearchRow row)
            {
                var fileId = row.fileJoin.internalId[0].searchValue.internalId;
                var fileName = row.fileJoin.name[0].searchValue;
                Console.WriteLine($"{fileId} - {fileName}");
            }
        }
    }
