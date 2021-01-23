     public Brush ConfirmBorder
        {
            get
            {
                if (textBox1.Text == textBox2.Text)
                    return new SolidColorBrush(Colors.Black);
                else
                    return
                        new SolidColorBrush(Colors.Red);
            }
        }
    <TextBox Name="textBox2" BorderBrush="{Binding ConfirmBorder}"  />
