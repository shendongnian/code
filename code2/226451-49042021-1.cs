    ConsoleRenderer.RenderDocument(
        new Document { Color = ConsoleColor.Gray }
            .AddChildren(
                new Grid { Stroke = LineThickness.None }
                    .AddColumns(10, 10, 10, 10, 10)
                    .AddChildren(
                        new Div("Customer"),
                        new Div("Sales"),
                        new Div("Fee"),
                        new Div("70% value"),
                        new Div("30% value"),
                        orders.Select(o => new object[] {
                            new Div().AddChildren(o.CustomerName),
                            new Div().AddChildren(o.Sales),
                            new Div().AddChildren(o.Fee),
                            new Div().AddChildren(o.Value70),
                            new Div().AddChildren(o.Value30)
                        })
                    )
            ));
