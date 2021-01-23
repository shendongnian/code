        private void textBox2_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo TypeOfLanguage = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
        }
