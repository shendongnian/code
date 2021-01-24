csharp
private readonly DynamoDBContext _context;
public CoffeeService()
{
      if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LAMBDA_TASK_ROOT")))
      {
         var chain = new CredentialProfileStoreChain();
         AWSCredentials awsCredentials;
         if (chain.TryGetAWSCredentials("Hackathon-coffee", out awsCredentials))
         {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, RegionEndpoint.APSoutheast2);
            _context = new DynamoDBContext(client, new DynamoDBContextConfig { ConsistentRead = true, SkipVersionCheck = true });
         }
         else
         {
            LambdaLogger.Log("Cannot Fetch Credentials");
         }
      }
      else
      {
         // Use credentials from IAM Role and region the function is running in.
         AmazonDynamoDBClient client = new AmazonDynamoDBClient();
         _context = new DynamoDBContext(client, new DynamoDBContextConfig { ConsistentRead = true, SkipVersionCheck = true });
      }
}
