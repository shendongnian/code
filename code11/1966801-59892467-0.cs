	protected void txtDate_TextChanged1(object sender, EventArgs e)
    {
		try
		{
			string mydateFormat="MM/dd/yyyy hh:m:sstt";
			var myCurrentCulture=CultureInfo.InvariantCulture;
			TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
			txtEndDate.Text = TimeZoneInfo.ConvertTimeFromUtc(DateTime.ParseExact(txtEndDate.Text, mydateFormat,myCurrentCulture), INDIAN_ZONE).ToString(mydateFormat);
		}
		catch(Exception ex){
		}
	}
