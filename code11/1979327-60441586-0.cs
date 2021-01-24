`
public class AppSettings
{
    AppSettings(IConfigurationRoot config)
    {
            myKey1 = config.GetSection("AppSettings:MyKey1").Value;
            myKey2 = config.GetSection("AppSettings:MyKey2").Value;
    }
    public string myKey1 { get; set; }
    public string myKey2 { get; set; }
}
`
Not ideal but it gets the job done and I can move on.
