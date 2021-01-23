    for (int count = 0; count < ds.Tables.Count; count++)
                {
                    DataGrid dg = new DataGrid();
                    dg.Name = ds.Tables[count].TableName.ToString();
                    dg.Margin = new Thickness(5);
                    dg.Width = 800;
                    dg.MaxHeight = 200;
                    DataGridTemplateColumn dgc = new DataGridTemplateColumn();
                    DataTemplate dtm = new DataTemplate();
    
                    FrameworkElementFactory btnReset = new FrameworkElementFactory(typeof(Button));
                    btnReset.SetValue(Button.ContentProperty, "Restore");
                    btnReset.SetValue(Button.ToolTipProperty, "Restore Selected Row");
                    btnReset.SetValue(Button.DataContextProperty, new Binding("TableName"));
                    
                    btnReset.AddHandler(Button.ClickEvent, new RoutedEventHandler(btn_Click));
    
                    //set the visual tree of the data template  
                    dtm.VisualTree = btnReset; 
                    dgc.CellTemplate = dtm;
                    dg.Columns.Add(dgc);
                    dg.AutoGenerateColumns = true;
                    dg.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    dg.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    dg.ItemsSource = ds.Tables[count].DefaultView;
                    stkCollection.Children.Add(dg);
                }
