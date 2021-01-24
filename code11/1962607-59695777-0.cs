      private void OnlyAllowNumbers(object sender, TextCompositionEventArgs e)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
                regex = null; //optional
                GC.Collect(); //optional
            }
    
            private void PreventPasteIntoTextbox(object sender, ExecutedRoutedEventArgs e)
            {
                if (e.Command == ApplicationCommands.Copy ||
                    e.Command == ApplicationCommands.Cut ||
                    e.Command == ApplicationCommands.Paste)
                {
                    e.Handled = true;
                }
            }
