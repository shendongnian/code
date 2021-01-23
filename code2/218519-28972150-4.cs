        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DefaultNamespace.Folder.sql.xshd"))
            {
                using (var reader = new System.Xml.XmlTextReader(stream))
                {
                    MyAvalonEdit.SyntaxHighlighting = 
                        ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader, 
                        ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);
                }
            }
        }
