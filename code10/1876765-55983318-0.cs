	private readonly SortedList<int, SortedSet<string>> _carsByYear = new SortedList<int, SortedSet<string>>();
	private void button1_Click(object sender, EventArgs e)
	{
		SortedSet<string> cars = null;
		string fileName = System.IO.Path.Combine(
			System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
			"cars.txt");
		
		foreach (string line in File.ReadLines(fileName))
		{
			if (!String.IsNullOrWhiteSpace(line))
			{
				if (Int32.TryParse(line, out int year))
				{   // We have a year
					if (!_carsByYear.ContainsKey(year))
					{
						cars = new SortedSet<string>();
						_carsByYear.Add(year, cars);
					}
					else
					{
						cars = _carsByYear[year];
					}
				}
				else
				{   // We have a car
					if (!cars.Contains(line))
					{
						cars.Add(line);
					}                    
				}
			}
		}
		listBox1.DataSource = _carsByYear.Keys.ToList();
	}
	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBox1.SelectedIndex != -1)
		{
			listBox2.DataSource = _carsByYear[(int)listBox1.SelectedItem].ToList();
		}
	}
	private void button2_Click(object sender, EventArgs e)
	{
		if (listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
		{
			int year = (int)listBox1.SelectedItem;
			string car = listBox2.SelectedItem.ToString();
			label1.Text = year.ToString();
			label2.Text = car;
		}
		else
		{
			label1.Text = "";
			label2.Text = "";
		}
	}
