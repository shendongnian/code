    public void ReformatDate(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox) sender;
        DateTime dt;
        // TODO: Work out what culture you want to parse/format in.
        if (DateTime.TryParseExact(textBox.Text, "yyyyMMdd",
                                   DateTimeStyles.None, out dt))
        {
            textBox.Text = dt.ToString("yyyy/MM/dd");
        }
    }
