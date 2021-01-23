        int Number;
        if (int.TryParse(TextBox1.Text, out Number) == false)
        {
            // parsing error
            Number = -1;
        }
        string odd = od.OddNumbers(Number);
