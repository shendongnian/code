    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void AppendNewButton(int i)
        {
            Button addB = new Button();
            addB.Content = i;
            addB.HorizontalAlignment = HorizontalAlignment.Left;
            var insertionPosition = tRTB.CaretPosition.GetInsertionPosition(LogicalDirection.Forward);
            
            var inline = new InlineUIContainer(addB);
            insertionPosition.Paragraph.Inlines.InsertAfter(
                (Inline)insertionPosition.Parent,
                inline);
            tRTB.CaretPosition = tRTB.CaretPosition.GetNextInsertionPosition(LogicalDirection.Forward);
        }
        public void tRTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.B)
            {
                AppendNewButton(7);
                e.Handled = true;
            }
        }
    }
