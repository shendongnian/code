    ConsoleRenderer.RenderDocument(
        new Document()
            .AddChildren(
                new Border {
                        Stroke = LineThickness.Wide,
                        Align = HorizontalAlignment.Left
                    }
                    .AddChildren(1337)
            )
    );
