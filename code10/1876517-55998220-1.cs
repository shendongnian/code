	private void Export_Click(object sender, RibbonControlEventArgs e)
	{
		Outlook.UserProperties MailUserProperties = null;
		Outlook.UserProperty MailUserProperty = null;
		Excel.Application oApp = new Excel.Application();
		Excel.Workbook oWB = oApp.Workbooks.Add();
		Excel.Worksheet oSheet = (Excel.Worksheet)oWB.Worksheets.get_Item(1);
		try
		{
			for (int i = 2; i <= selectedFolder.Items.Count; i++)
			{
				Outlook.MailItem mail = (Outlook.MailItem)selectedFolder.Items[i];
				MailUserProperties = mail.UserProperties;
				oSheet.Cells[i, 1] = i.ToString();
				oSheet.Cells[i, 2] = mail.Sender;
				oSheet.Cells[i, 3] = mail.Subject;
				oSheet.Cells[i, 4] = mail.ReceivedTime.ToLongDateString();
				for (int j = 1; j <= MailUserProperties.Count; j++)
				{
					MailUserProperty = MailUserProperties[j];
					if (MailUserProperty != null)
					{
						var ownership = string.Empty;
						var completedTime = string.Empty;
						var timeSpent = string.Empty;
						try
						{
							ownership = mail.UserProperties["Ownership"].Value;
						}
						catch (Exception)
						{
							ownership = string.Empty; //or you can pass a string like <MISSING>
						}
						finally
						{
							oSheet.Cells[i, 5] = ownership;
						}
						try
						{
							completedTime = mail.UserProperties["CompletedTime"].Value;
						}
						catch (Exception)
						{
							completedTime = string.Empty;
						}
						finally
						{
							oSheet.Cells[i, 6] = completedTime;
						}
						try
						{
							timeSpent = mail.UserProperties["TimeSpent"].Value;
						}
						catch (Exception)
						{
							timeSpent = string.Empty;
						}
						finally
						{
							oSheet.Cells[i, 7] = timeSpent;
						}
					}
				}
			}
			oSheet.UsedRange.Columns.AutoFit();
		}
		catch (System.Runtime.InteropServices.COMException ex)
		{
			Console.WriteLine(ex.ToString());
		}
		finally
		{
			// Code to save in Excel
		}
	}
