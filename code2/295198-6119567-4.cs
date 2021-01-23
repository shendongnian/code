        int number;
        try
        {
            number = int.Parse(textBox1.Text);
        }
        catch (MyException exception)
        {
            exception.TextBox.Background = new SolidColorBrush(Colors.Red);
        }
