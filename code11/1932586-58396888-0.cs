        public interface IApiSettings
            {
                string UrlToCall { get; set; }
            }
            public class ApiSettings:IApiSettings
            {
                public string UrlToCall { get; set; }
                public ApiSettings()
                {
				        ...
                    Console.WriteLine($"ApiSettings");
					        ...
                }
            }
        
            public class IInfraApp{}
            public class InfraApp : IInfraApp
            {
                private IApiSettings _ApiSettings;
                //using Microsoft.Extensions.Options:
                public InfraApp(IOptions<ApiSettings> settings)
                {
                    _ApiSettings = (IApiSettings)settings.Value;
                    Console.WriteLine($"InfraApp {_ApiSettings.UrlToCall}");
                }
            }
