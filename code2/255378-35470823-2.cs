    protected void TextBoxChanged_DateTimeTest(object sender, EventArgs e)
        {
            Page.Validate("vg2");
            if (!Page.IsValid)
            {
                TextBox tb1 = (TextBox)sender;
                IFormatProvider culture = new CultureInfo("en-AU", true);
    
                //if page is not valid, then validate the date here and default it to today's date & time, 
                String[] formats = { "dd MM yyyy HH:mm", "dd/MM/yyyy HH:mm", "dd-MM-yyyy HH:mm" };
                DateTime dt1;
                DateTime.TryParseExact(tb1.Text, formats, culture, DateTimeStyles.AdjustToUniversal, out dt1);
                if (dt1.ToShortDateString() != "1/01/0001")
                    tb1.Text = dt1.ToShortDateString() + " " + dt1.ToShortTimeString();
                else
                    tb1.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            }
        }
