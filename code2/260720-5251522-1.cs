    DataGridTemplateColumn column = new DataGridTemplateColumn
       {
          Header = "Name",
          Width = 100,
       };
    FrameworkElementFactory ftb = new FrameworkElementFactory(typeof(TextBlock));
    Binding b = new Binding("Name");
    ftb.SetValue(TextBlock.Text, b);
    ftb.SetValue(TextBlock.TextTrimming, TextTrimming.CharacterEllipsis);    
    DataTemplate ct = new DataTemplate();
    ct.VisualTree = ftb;
    column.CellTemplate = ct;
