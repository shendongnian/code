    public class ServiceX 
    {
        public ServiceX(Func<BasicAwsCredentials, AmazonS3Config, IAmazonS3Client> factory)
        {
            this._amazonS3Factory = factory; 
        }
        private readonly Func<BasicAwsCredentials, AmazonS3Config, IAmazonS3Client> _amazonS3Factory; 
        public void Do()
        {
            IAmazonS3Client client = this._amazonS3FActory(credentials, config); 
            // do something with client
        }
    }
