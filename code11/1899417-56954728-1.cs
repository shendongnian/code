    public async Task<ActionResult> SendMany([FromBody] EmailManyDto email)
	{
		foreach (var recipient in email.Recipients)
		{
			// send your mail
		}
	}
	
