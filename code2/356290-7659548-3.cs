    private int row = 2;
        private int col = 2;
        private void btn1_Click(object sender, RoutedEventArgs args)
        {
            Button cmd = (Button)sender;
            string txt = cmd.Tag.ToString();
            int r = int.Parse("" + txt[0]);
            int c = int.Parse("" + txt[1]);
            if (Math.Abs(r - row) + Math.Abs(c - col) == 1)
            {
                MessageBox.Show(r + "  " + c);
                Button nearButton = grd1.Children.Cast<Button>().First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
                Object tmp = nearButton.Content;
                nearButton.Content = cmd.Content;
                cmd.Content = tmp;
            }
        }
