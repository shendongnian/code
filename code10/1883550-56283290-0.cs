    await folder.OpenAsync(FolderAccess.ReadOnly).ConfigureAwait(false);
    
    var ids = (await folder.SortAsync(SearchOptions.All, SearchQuery.All, new[] {OrderBy.ReverseDate}).ConfigureAwait(false)).UniqueIds
        .Skip(offset)
        .Take(limit)
        .ToArray();
    
    var items = await folder.FetchAsync(ids,
        MessageSummaryItems.Envelope | MessageSummaryItems.Flags | MessageSummaryItems.Full |
        MessageSummaryItems.UniqueId | MessageSummaryItems.PreviewText | MessageSummaryItems.BodyStructure).ConfigureAwait(false);
