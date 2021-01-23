       @(Html.Telerik().Grid(Model)
            .Name("Grid")
            .Columns(columns =>
            {
               columns.Bound(c => c.SheetLine)
                    .Aggregate(a => a.Count())
                    .GroupHeaderTemplate(@<text>@item.Key (@item.Count)</text>).Hidden(true);
        
                columns.Bound(c => c.PrintLine)           
                    .GroupHeaderTemplate(@<text>@item.Key</text>).Hidden(true);
        
                columns.Bound(c => c.SelectionLine)          
                    .GroupHeaderTemplate(@<text>@item.Key</text>).Hidden(true);
        
                columns.Bound(c => c.VSACode);
                columns.Bound(c => c.Bucket100)
                    .Title("First");
            })
            .Groupable(groupable => groupable.Groups(group =>
                                {
                                    group.Add(g => g.SheetLine);
                                    group.Add(g => g.PrintLine);
                                    group.Add(g => g.SelectionLine);
                                }).Visible(false))
        )
