    public static class PromptForTextAndSelection
    {
        public static string ShowDialog(string caption, string text, string selStr)
        {
            Form prompt = new Form();
            prompt.Width = 280;
            prompt.Height = 160;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = text };
            TextBox textBox = new TextBox() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
            Label selLabel = new Label() { Left = 16, Top = 66, Width = 88, Text = selStr };
            ComboBox cmbx = new ComboBox() { Left = 112, Top = 64, Width = 144 };
            cmbx.Items.Add("Dark Grey");
            cmbx.Items.Add("Orange");
            cmbx.Items.Add("None");
            Button confirmation = new Button() { Text = "In Ordnung!", Left = 16, Width = 80, Top = 88, TabIndex = 1, TabStop = true };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(selLabel);
            prompt.Controls.Add(cmbx);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.ShowDialog();
            return string.Format("{0};{1}", textBox.Text, cmbx.SelectedItem.ToString());
        }
    }
