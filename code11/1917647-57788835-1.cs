        public MainWindow()
        {
            InitializeComponent();
            Rtb.AppendText("lineoftextlineoftextlineoftextlineoftext");
            Rtb.AppendText(Environment.NewLine);
            Rtb.AppendText("lineoftextlineoftextlineoftextlineoftext");
        }
        private void Button_Get(object sender, RoutedEventArgs e)
        {
            TextPointer start = Rtb.Document.ContentStart;
            TextPointer curPosition = Rtb.CaretPosition;
            TextRange range = new TextRange(start, curPosition);
            Debug.WriteLine("Caret position : " + range.Text.Length);
            Rtb.Focus();
        }
        private void Button_Set(object sender, RoutedEventArgs e)
        {
            int value = int.Parse(DesiredPositionBox.Text);
            Rtb.CaretPosition = Rtb.Document.ContentStart;
            for (int i = 0; i < value; i++)
            {
                TextPointer move = Rtb.CaretPosition.GetNextInsertionPosition(LogicalDirection.Forward);
                if (move != null)
                    Rtb.CaretPosition = move;
            }
            Rtb.Focus();
        }
