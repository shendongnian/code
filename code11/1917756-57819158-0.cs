            [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                string text = textBox.Text;
                DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
                (dte.ActiveDocument.Selection as EnvDTE.TextSelection).Text = text;
            }
