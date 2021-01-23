        private void tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char[] inputChar = e.Text.ToCharArray();
            if (char.IsNumber(inputChar[0]))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
