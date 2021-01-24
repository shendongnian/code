    var roleArnToAssume = "arn:aws:iam::111111111111:role/xxx-xxxx";
    var assumeRoleReq = new AssumeRoleRequest();
    assumeRoleReq.DurationSeconds = 3600;
    assumeRoleReq.RoleSessionName = "XXXX";
    assumeRoleReq.RoleArn = roleArnToAssume;
    assumeRoleReq.ExternalId = "xxxxxxxxxxxxxxxx";
    var endpoint = Amazon.RegionEndpoint.USWest1;
    var e = endpoint.GetEndpointForService("S3"); 
    Amazon.Runtime.AWSCredentials credentials =
                    new Amazon.Runtime.BasicAWSCredentials("XXXXXXXXXXXXXXXXXX", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
    
    var clientArn = new AmazonSecurityTokenServiceClient(credentials);
    var assumeRoleRes = GetAssumeRoleResponseAsync(client: clientArn, request: assumeRoleReq);
    
    string tempAccessKeyId = assumeRoleRes.Result.Credentials.AccessKeyId;
