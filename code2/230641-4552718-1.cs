            Int32 testInt;
            if (!Int32.TryParse("123", out testInt))
            {
                MessageBox.Show("Is not a Int32!");
                return; // abbrechen
            }
            MessageBox.Show("The parst Int32-value is " + testInt);
