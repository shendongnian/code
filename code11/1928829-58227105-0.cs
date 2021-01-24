    private void TxtOperator_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^+^\-^\/^\*^\(^\)]");
            MatchCollection matches = regex.Matches(txtOperator.Text);
            if (matches.Count > 0)
            {
                MessageBox.Show("Please input an operator.");
                txtOperator.Text = "";
            }
        }
