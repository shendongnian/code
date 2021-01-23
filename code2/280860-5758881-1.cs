    public double RecoDoseSize { get; set; }
	private void Submit2_Click(object sender, RoutedEventArgs e)
	{
		TotalContentProduct = double.Parse(textBox7.Text);
		double enteredSize;
		if (!double.TryParse(textBox8.Text, out enteredSize) || enteredSize <= 0)
		{
			MessageBox.Show("Please Enter the recommended dose size for this product");
			textBox8.Focus();
			return;
		}
		RecoDoseSize = enteredSize;
		NoOfDosespUnit = TotalContentProduct / recoDoseSize;
	}
