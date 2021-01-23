    public Window1()
            {
                InitializeComponent();
     
                // add a Frame for navigation
                Frame frame = new Frame();
                this.Content = frame;
                //add FlowDocument
                FlowDocument doc = new FlowDocument();
                frame.Navigate(doc);
     
                //add Table
                Table table = new Table();
                doc.Blocks.Add(table );
                TableRowGroup group = new TableRowGroup();
                table.RowGroups.Add(group );
     
                TableColumn col1 = new TableColumn();
                TableColumn col2 = new TableColumn();
                table.Columns.Add(col1 );
                table.Columns.Add(col2);
     
                TableRow row1 = new TableRow();
                TableCell cel1 = new TableCell();
                row1.Cells.Add(cel1);
     
                group.Rows.Add(row1);
     
                //add Section
                Section mySection = new Section();
                //add section to the Table cell.
                cel1.Blocks.Add(mySection);
     
                Paragraph paraValue = new Paragraph();
                Hyperlink hl = new Hyperlink(new Run("Click Here to Google"));
                hl.Foreground = Brushes.Red;
                paraValue.Inlines.Add(hl);
     
                hl.FontSize = 11;
                hl .NavigateUri =new Uri ("Http://www.google.cn");
     
                mySection.Blocks.Add(paraValue);
            }
