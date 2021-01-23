        void textBox1_Validating(object sender, CancelEventArgs e)
        {
            DateTime dateEntered;
            if (DateTime.TryParseExact(textBox1.Text, "HH:mm", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dateEntered))
            {
                MessageBox.Show(dateEntered.ToString());
            }
            else
            {
                MessageBox.Show("You need to enter valid 24hr time");
            }
        }
