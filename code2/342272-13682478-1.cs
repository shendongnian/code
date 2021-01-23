            if (char.IsDigit(inputChar[0]))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
