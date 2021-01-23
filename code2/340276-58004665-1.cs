        private void CursorIssueHandler(object sender, TextCompositionEventArgs e)
        {
            var TB = (sender as TextBox);
            Regex regex = new Regex("[^0-9a-zA-Z-]+");
            bool Valid = regex.IsMatch(e.Text);
            //System.Diagnostics.Debug.WriteLine(Valid); // check value for valid n assign e.Handled accordingly your requirement from regex
            e.Handled = Valid;
         }
