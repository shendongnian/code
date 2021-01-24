        private static bool validateFloatNumber(string Text, TextBox Box)
        {
            Regex regex = new Regex("^[0-9]{1,9}([,.][0-9]{1,4})?$");
            bool result = regex.IsMatch(Text);
            if (!result)
            {
                if (Text.Length == 0)
                {
                    Box.Background = Brushes.Gray;
                }
                else
                {
                    Box.Background = Brushes.Red;
                }
            }
            else
            {
                Box.Background = Brushes.Transparent;
            }
            return result;
        }
