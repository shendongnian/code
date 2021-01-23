    public static class ReadOnlyModeWithCursor
    {
        public static readonly DependencyProperty IsModeEnabledProperty = DependencyProperty.RegisterAttached("IsModeEnabled",
                                                                                                              typeof(bool),
                                                                                                              typeof(ReadOnlyModeWithCursor),
                                                                                                              new FrameworkPropertyMetadata(OnModeEnabledChanged));
        private static ContextMenu _contextMenuWithCopyOnly = new ContextMenu();
        static ReadOnlyModeWithCursor()
        {
            _contextMenuWithCopyOnly.Items.Add(new MenuItem { Command = ApplicationCommands.Copy });
        }
        public static bool GetIsModeEnabled(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }
            return (bool)textBox.GetValue(IsModeEnabledProperty);
        }
        public static void SetIsModeEnabled(TextBox textBox, bool value)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }
            textBox.SetValue(IsModeEnabledProperty, value);
        }
        private static void NoCutting(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Cut)
            {
                e.Handled = true;
            }
        }
        private static void NoDragCopy(object sender, DataObjectCopyingEventArgs e)
        {
            if (e.IsDragDrop)
            {
                e.CancelCommand();
            }
        }
        private static void OnModeEnabledChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)dependencyObject;
            var isEnabled = (bool)e.NewValue;
            if (isEnabled)
            {
                textBox.PreviewTextInput += textBox_PreviewTextInput;
                textBox.PreviewKeyDown += textBox_PreviewKeyDown;
                DataObject.AddPastingHandler(textBox, Pasting);
                DataObject.AddCopyingHandler(textBox, NoDragCopy);
                CommandManager.AddPreviewExecutedHandler(textBox, NoCutting);
                // Default context menu has cut & paste, we want only copy.
                textBox.ContextMenu = _contextMenuWithCopyOnly;
                // Remove if you want to set the style of readonly textboxes via styles
                textBox.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            }
            else
            {
                textBox.PreviewTextInput -= textBox_PreviewTextInput;
                textBox.PreviewKeyDown -= textBox_PreviewKeyDown;
                DataObject.RemovePastingHandler(textBox, Pasting);
                DataObject.RemoveCopyingHandler(textBox, NoDragCopy);
                CommandManager.RemovePreviewExecutedHandler(textBox, NoCutting);
                textBox.ClearValue(TextBox.ContextMenuProperty);
                textBox.ClearValue(TextBox.BackgroundProperty);
            }
        }
        private static void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }
        private static void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //pressing space doesn't raise PreviewTextInput, reasons here http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/446ec083-04c8-43f2-89dc-1e2521a31f6b?prof=required
            if (e.Key == Key.Space || e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }
        private static void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }
    }
