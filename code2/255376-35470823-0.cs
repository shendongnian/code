    protected void TextBox_Changed(object sender, EventArgs e)
    {
        TextBox tb1 = (TextBox)sender;
        Page.Validate();
        if (Page.IsValid)
        {
            if (DateTime.Parse(tb1.Text).ToShortDateString() == DateTime.Today.ToShortDateString())
                //do something positive
            else
                //do something else negative like error handling or something
        }
        else
        {
            //if page is not valid, then validate the date again here and default it to today's date, or accept the good date (validation fail could be due to something else)
            IFormatProvider culture = new CultureInfo("en-AU", true);
            String[] formats = { "dd MM yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };
            DateTime dt1;
            DateTime.TryParseExact(tb1.Text, formats, culture, DateTimeStyles.AdjustToUniversal, out dt1); 
            if (dt1.ToShortDateString() != "1/01/0001")
                tb1.Text = dt1.ToShortDateString();
            else
                tb1.Text = DateTime.Today.ToShortDateString();
        }
    }
