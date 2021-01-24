    private void InputNumber_TextChanged(object sender, TextChangedEventArgs e)
    {
        string number = InputNumber.Text;
        if(int.TryParse(number, out int value))
        {
            bool isEven = value % 2 == 0;
            OutputNumber.Text = number + (isEven ? " is a even number" : " is a odd number");
            if (InputNumber.Text == string.Empty)
            {
                OutputNumber.Clear();
            }
        }
    }
