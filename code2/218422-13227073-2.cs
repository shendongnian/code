    try
	{
		string hour = stringFormat.Substring(0, 2);
		string min = stringFormat.Substring(2, 2);
		DateTime dt = new DateTime();
		dt = Convert.ToDateTime(hour+":"+min);
		return String.Format("{0:t}", dt); ;
	}
	catch (Exception ex)
	{
		return "Please Enter Correct format like <0559>";
	}
