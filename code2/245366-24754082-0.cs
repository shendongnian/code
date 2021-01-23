        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                int i=tb.Text.Length;
                //Set your desired minimumlength here '7'
                if (i<7)
                {
                    MessageBox.Show("Too short Password");
                    return;
                }
            }
            else
            e.Cancel = true;
        }
