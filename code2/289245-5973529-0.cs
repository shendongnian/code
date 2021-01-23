	void Main()
	{
		// This is the list from your example.
		var contactmoments = new List<ContactMoment> {
			new ContactMoment { From = "CALLER_A", To = "Caller_B", Type = ContactType.Voice },
			new ContactMoment { From = "CALLER_A", To = "Caller_C", Type = ContactType.Text },
			new ContactMoment { From = "CALLER_A", To = "Caller_B", Type = ContactType.VoiceMail },
			new ContactMoment { From = "CALLER_A", To = "Caller_B", Type = ContactType.Voice },
			new ContactMoment { From = "CALLER_A", To = "Caller_C", Type = ContactType.Text }
		};
		
		// Group by the properties 'From', 'To' and 'Type'
		var groups = contactmoments.GroupBy(c => new { c.From, c.To, c.Type });
		
		// Write the properties of the key and the size of the group to the console.
		foreach(var group in groups)
		{
			Console.WriteLine("{0,-15} {1,-15} {2,-15} {3}", group.Key.Type, group.Key.From, group.Key.To, group.Count());
		}
	}
	
	class ContactMoment
	{
		public string From { get; set; }
		public string To { get; set; }
		public ContactType Type { get; set; }
	}
	
	enum ContactType
	{
		Voice = 1,
		Text = 2,
		VoiceMail = 3
	}
