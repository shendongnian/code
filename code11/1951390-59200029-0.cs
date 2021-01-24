public interface IAmazonS3FirstConfig : IAmazonS3
{
}
public class AmazonS3ClientFirstConfig : AmazonS3Client, IAmazonS3FirstConfig
{
    public AmazonS3ClientFirstConfig(BasicAWSCredentials credentials, AmazonS3Config config)
        : base(credentials, config)
    {
    }
}
Using the ad-hoc class and interface to register this configuration, and another couple for the second configuration.
