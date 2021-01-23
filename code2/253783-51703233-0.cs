			DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-1);
			while (startDate.AddMinutes(30) <= endDate)
			{
				string sdate = startDate.ToString("yyyy-MM-dd HH:mm");
				string edate = startDate.AddMinutes(29).ToString("yyyy-MM-dd HH:mm");
				string display = string.Format("{0} - {1}", sdate, edate);
				Console.WriteLine(display);
				startDate = startDate.AddMinutes(30);
			}
