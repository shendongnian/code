    ConsoleTableBuilder
        .From(orders
            .Select(o => new object[] {
                o.CustomerName,
                o.Sales,
                o.Fee,
                o.Value70,
                o.Value30
            })
            .ToList())
        .WithColumn(
            "Customer",
            "Sales",
            "Fee",
            "70% value",
            "30% value")
        .WithFormat(ConsoleTableBuilderFormat.Minimal)
        .WithOptions(new ConsoleTableBuilderOption { DividerString = "" })
        .ExportAndWriteLine();
