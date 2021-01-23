    int year;
    if (int.TryParse(textBox1.Text, out year))
    {
        DateTime dt = new DateTime(year, 1, 1);
    }
    else
    {
        // Handle input
    }
