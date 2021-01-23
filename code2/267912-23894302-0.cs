    public static class PromptForTextAndBoolean
    {
        public static string ShowDialog(string caption, string text, string boolStr)
        {
            Form prompt = new Form();
            prompt.Width = 280;
            prompt.Height = 160;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = text };
            TextBox textBox = new TextBox() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
            CheckBox ckbx = new CheckBox() { Left = 16, Top = 60, Width = 240, Text = boolStr };
            Button confirmation = new Button() { Text = "Okay!", Left = 16, Width = 80, Top = 88, TabIndex = 1, TabStop = true };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(ckbx);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.ShowDialog();
            return string.Format("{0};{1}", textBox.Text, ckbx.Checked.ToString());
        }
    }
