    using Microsoft.Bot.Connector;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    namespace NetBot.Credentials
    {
    	public class BotFileCredentialProvider : SimpleCredentialProvider
    	{
    		private const string BotFile = "NetBot.bot";
    
    		public BotFileCredentialProvider()
    		{
    			var assembly = Assembly.GetExecutingAssembly();
    			var resourceName = assembly.GetManifestResourceNames().First(resource => resource.Contains(BotFile));
    
    			using (var stream = assembly.GetManifestResourceStream(resourceName))
    			{
    				dynamic botConfig = JsonConvert.DeserializeObject(new StreamReader(stream).ReadToEnd());
    				IEnumerable<dynamic> services = botConfig.services;
    				dynamic endpoint = services.FirstOrDefault(service => service.type == "endpoint");
    
    				if (endpoint != null)
    				{
    					AppId = endpoint.appId;
    					Password = endpoint.appPassword;
    				}
    			}
    		}
    	}
    }
