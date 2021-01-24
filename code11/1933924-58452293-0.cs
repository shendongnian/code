    private void YarnWeightTextbox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (int.TryParse(textBox.Text, out int yarnWeight))
                {
                    var yarnLength = (yarnWeight / 50) * ft3.garnlangd1;
                    YarnLengthTextbox.Text = yarnLength.ToString();
                }
            }
        }
