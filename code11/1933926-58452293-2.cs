    private void YarnWeightTextbox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (float.TryParse(textBox.Text, out int yarnWeight))
                {
                    var yarnLength = (yarnWeight / 50.0) * YarnComboBox.SelectedItem.garnlangd1;
                    YarnLengthTextbox.Text = yarnLength.ToString();
                }
                else
                {
                    YarnLengthTextbox.Text = string.Empty;
                }
            }
        }
