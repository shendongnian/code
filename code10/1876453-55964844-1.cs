	List<MailItem> ReceivedEmail = new List<MailItem>();
	foreach (var testMail in items)
	{
		try
		{
			ReceivedEmail.Add((MailItem)testMail);
		}
		catch (System.Exception ex)
		{
			;
		}
	}
