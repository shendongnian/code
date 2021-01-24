	var getSessionTokenRequest = new GetSessionTokenRequest
	{
		DurationSeconds = 7200
	};
	var stsClient = hostContext.Configuration.GetAWSOptions().CreateServiceClient<IAmazonSecurityTokenService>();
    var iden = stsClient.GetCallerIdentityAsync(new GetCallerIdentityRequest { }).Result;
    System.Console.WriteLine($"A={iden.Account} ARN={iden.Arn} U={iden.UserId}");
