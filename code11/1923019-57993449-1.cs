"EmailSettings__Sender": "xy@gmail.com",
"EmailSettings__From": "Hello xy@gmail.com",
Can be bound to the following POCO
csharp
 public class EmailSettings
 {
       public string Sender { get; set; }
       public string From { get; set; }
 }
using the `ConfigurationBuilder` like this:
chsarp
   var config = new ConfigurationBuilder()
                .SetBasePath(executionContextOptions.AppDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile("local.settings.json", true, true)
                .Build();
 // other initialization code
config.GetSection(nameof(EmailSettings)).Get<EmailSettings>()
in the startup of your function. For deployment, put those key / value pairs into the App Settings of your function in the portal.
Thats how we set it up in production and it works fine.
