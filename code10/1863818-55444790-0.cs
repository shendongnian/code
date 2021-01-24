    HashSet<EmailAction> activityTypes = new HashSet<EmailAction> { EmailAction.None };
    
    var emailActivity = new List<EmailActivity>
    {
    	new EmailActivity { Activity = new List<MemberActivity>{ new MemberActivity { Action = EmailAction.None } }, EmailAddress = "a" },
    	new EmailActivity { Activity = new List<MemberActivity>{ new MemberActivity { Action = EmailAction.Click } }, EmailAddress = "b" }
    };
    
    // Example with Any but All can be used as well
    var activityEmailAddresses = emailActivity
    	.Where(x => x.Activity.Any(_ => _.Action.HasValue && activityTypes.Contains(_.Action.Value)))
    	.Select(x => x.EmailAddress)
        .ToArray();
    // Result is [ "a" ] 
