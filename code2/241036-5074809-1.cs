        richtTextBox.Selection.Text =
             "Lorem ipsum pro falli dicunt volumus te, ex velit probatus corrumpit per. His ex reque aperiam alienum, liber indoctum per an. Sed ei nibh cibo minim, et eam graeci suavitate. Vim iusto gubergren repudiandae ei.";
    private void testButton_Click(object sender, RoutedEventArgs e)
    {
        var rect = richtTextBox.Selection.Start.GetCharacterRect(System.Windows.Documents.LogicalDirection.Forward);
        var richtTextBoxPosition =
            richtTextBox.TransformToVisual(Application.Current.RootVisual).Transform(new Point(0, 0));
        var popup = new Popup()
                        {
                            HorizontalOffset = richtTextBoxPosition.X + rect.X,
                            VerticalOffset = richtTextBoxPosition.Y + rect.Y + richtTextBox.FontSize,
                            Height = 150,
                            Width = 100
                        };
        popup.Child = new ListBox()
        {
            Background = new SolidColorBrush(Colors.Red),
            Height = 150,
            Width = 100
        }; // use your custom UC here
        popup.IsOpen = true;
    }
