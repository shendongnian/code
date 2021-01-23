    DataGridTemplateColumn column = new DataGridTemplateColumn
       {
          Header = "Name",
          Width = 100,
       };
    FrameworkElementFactory ftb = new FrameworkElementFactory(typeof(TextBlock));
    ftb.SetValue(TextBlock.TextTrimming, TextTrimming.CharacterEllipsis);    
    DataTemplate ct = new DataTemplate();
    ct.VisualTree = ftb;
    column.CellTemplate = ct;
