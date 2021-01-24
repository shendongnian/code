    public class FlowPaginator : DocumentPaginator
    {
        string[] headers = { "Trans No.", "Order No.", "Type", "Price", "Quantity", "Value" };
        int code;
        DocumentPaginator paginator;
        public FlowPaginator(FlowDocument doc, int customerCode)
        {
            code = customerCode;
            paginator = ((IDocumentPaginatorSource)doc).DocumentPaginator;
        }
        public override bool IsPageCountValid => paginator.IsPageCountValid;
        public override int PageCount => paginator.PageCount;
        public override Size PageSize { get => paginator.PageSize; set => paginator.PageSize = value; }
        public override IDocumentPaginatorSource Source => paginator.Source;
        public override DocumentPage GetPage(int pageNumber)
        {
            var oldPage = paginator.GetPage(pageNumber);
            var visual = new ContainerVisual();
            var header = new DrawingVisual();
            var footer = new DrawingVisual();
            #region Heading
            var heading = new Grid() { Width = oldPage.Size.Width - 2 * 96 };
            heading.RowDefinitions.Add(new RowDefinition());
            heading.RowDefinitions.Add(new RowDefinition());
            heading.ColumnDefinitions.Add(new ColumnDefinition());
            heading.ColumnDefinitions.Add(new ColumnDefinition());
            var t1 = new TextBlock() { Text = "Trade Report", FontSize = 24, FontWeight = FontWeights.Bold, HorizontalAlignment = HorizontalAlignment.Center };
            var t2 = new TextBlock() { Text = "Customer Code: " + code, FontWeight = FontWeights.SemiBold, HorizontalAlignment = HorizontalAlignment.Left };
            var t3 = new TextBlock() { Text = "Date: " + DateTime.Now.ToShortDateString(), FontWeight = FontWeights.SemiBold, HorizontalAlignment = HorizontalAlignment.Right };
            Grid.SetColumn(t1, 0); Grid.SetRow(t1, 0); Grid.SetColumnSpan(t1, 2);
            Grid.SetColumn(t2, 0); Grid.SetRow(t2, 1);
            Grid.SetColumn(t3, 1); Grid.SetRow(t3, 1);
            heading.Children.Add(t1);
            heading.Children.Add(t2);
            heading.Children.Add(t3);
            heading.Measure(new Size(oldPage.Size.Width, oldPage.Size.Height));
            heading.Arrange(new Rect(heading.DesiredSize));
            var headingSize = new Size() { Height = heading.ActualHeight, Width = heading.ActualWidth };
            #endregion
            #region TableHeader
            var tableHeader = new Grid() { Width = oldPage.Size.Width - 2 * 96 };
            var border = new Border()
            {
                Background = new SolidColorBrush(Colors.LightGray),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0, 1, 0, 1),
                Child = tableHeader
            };
            for (int i = 0; i < headers.Length; i++)
            {
                tableHeader.ColumnDefinitions.Add(new ColumnDefinition());
                var head = new TextBlock() { Text = headers[i], FontWeight = FontWeights.Bold };
                if(i > 2)
                {
                    tableHeader.ColumnDefinitions[i].Width = new GridLength(138);
                    head.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    tableHeader.ColumnDefinitions[i].Width = new GridLength(70);
                    head.HorizontalAlignment = HorizontalAlignment.Center;
                }
                Grid.SetColumn(head, i);
                tableHeader.Children.Add(head);
            }
            border.Measure(new Size(oldPage.Size.Width, oldPage.Size.Height));
            border.Arrange(new Rect(border.DesiredSize));
            var borderSize = new Size() { Height = border.ActualHeight, Width = border.ActualWidth };
            #endregion
            using (var dc = header.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(heading), null, new Rect(new Point(96, 96), headingSize));
                dc.DrawRectangle(new VisualBrush(border), null, new Rect(new Point(96, 96 * 1.55), borderSize));
            }
            using(var dc = footer.RenderOpen())
            {
                var text = new TextBlock() { Text = "Page: " + (pageNumber + 1) };
                text.Measure(new Size(oldPage.Size.Width, oldPage.Size.Height));
                text.Arrange(new Rect(text.DesiredSize));
                var texSize = new Size() { Height = text.ActualHeight, Width = text.ActualWidth };
                dc.DrawRectangle(new VisualBrush(text), null, new Rect(oldPage.Size.Width - 96, oldPage.Size.Height - 96, texSize.Width, texSize.Height));
            }
            visual.Children.Add(header);
            visual.Children.Add(oldPage.Visual);
            visual.Children.Add(footer);
            return new DocumentPage(visual);
        }
    }
