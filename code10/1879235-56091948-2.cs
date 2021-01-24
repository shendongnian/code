        private void button1_Click(object sender, EventArgs e)
        {
            // Read the setting value (string->int)
            if (int.TryParse(Properties.Settings.Default.CounterText, out int num))
            {
                // Increment value
                num++;
                // Update the setting (int->string)
                Properties.Settings.Default.CounterText = num.ToString();
                // The system will automatically update the label text.
            }
        }
