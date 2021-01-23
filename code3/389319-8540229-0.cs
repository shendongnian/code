    FlowDocument doc = new FlowDocument();
    foreach (Labels label in labels)
    {
        Paragraph p = new Paragraph();
        p.Inlines.Add(label.name + "\n");
        p.Inlines.Add(label.age + "\n");
        p.Inlines.Add(label.price + "\n");
        doc.Blocks.Add(p);
    }
