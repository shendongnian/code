        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("Escape was pressed");
                e.Handled = true;
            }
            base.OnKeyUp(e);
        }
