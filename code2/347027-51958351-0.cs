    public class AWSClass : IDisposable
        {
            Amazon.EC2.AmazonEC2Client _client;
    
            public AWSClass(string region, string AccessKey, string Secret)
            {
                RegionEndpoint EndPoint = RegionEndpoint.GetBySystemName(region);
                Amazon.Runtime.BasicAWSCredentials Credentials = new Amazon.Runtime.BasicAWSCredentials(AccessKey, Secret);
                _client = new AmazonEC2Client(Credentials, EndPoint);
            }
    
            public void Dispose()
            {
                _client = null;
            }
            
            public void StopInstance(string InstanceID)
            {
                StopInstancesResponse response = _client.StopInstances(new StopInstancesRequest
                {
                    InstanceIds = new List<string> {InstanceID }
                });
                //Can also do something with the response object too
            }
    
            public void StartInstance(string InstanceID)
            {
                StartInstancesResponse response = _client.StartInstances(new StartInstancesRequest
                {
                    InstanceIds = new List<string> { InstanceID }
                });
    
            }
    
        }
