    private void YarnWeightTextbox_TextChanged(object sender, EventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (float.TryParse(textBox.Text, out var yarnWeight) && YarnComboBox.SelectedItem is Class2 class2)
            {
                var yarnLength = (yarnWeight / 50.0) * class2.garnlangd1;
    
                YarnLengthTextbox.Text = yarnLength.ToString();
            }
            else
            {
                YarnLengthTextbox.Text = string.Empty;
            }
        }
    }
