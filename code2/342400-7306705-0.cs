        private void textBox1_ValueChanged(object sender, EventArgs e)
        {
            TextBox changedTxt = sender as TextBox;
            for (int i = 1; i < value; i++)
                if (textBoxes[i] == changedTxt)
                {
                    Label lblToChange = labeld[i];
                    lblToChange.Text = changedTxt.Text;
                    break;
                }
        }
