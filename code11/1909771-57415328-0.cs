var region = Amazon.RegionEndpoint.EUWest1;
var  snsClient = new AmazonSimpleNotificationServiceClient(region);
var sb = new StringBuilder()
                .Append("Line1.\n")
                .Append("Line2.\n")
                .Append("Line4\n");
var message = sb.ToString();
// Create request
var publishRequest = new PublishRequest
{
    PhoneNumber = phone,
    Message = message,                
};
// Send SMS
var response = await snsClient.PublishAsync(publishRequest);
The message I received contained :
Line1.
Line2.
Line4.
I decided to get fancy and changed the last line to :
.Append("Line4ΑΒΓ£§¶\n");
I received this text without problems too
