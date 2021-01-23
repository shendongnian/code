         private void txtExpecedProfit_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric((TextBox)sender,e);
        }
        private void CheckIsNumeric(TextBox sender,TextCompositionEventArgs e)
        {
            decimal result;
            bool dot = sender.Text.IndexOf(".") < 0 && e.Text.Equals(".") && sender.Text.Length>0;
            if (!(Decimal.TryParse(e.Text, out result ) || dot )  )
            {
                e.Handled = true;
            }
        }
