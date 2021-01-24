    using System;
    using Elastic.Managed.Configuration;
    using Elastic.Managed.ConsoleWriters;
    using Elastic.Managed.FileSystem;
    
    namespace Elastic.Managed.Example
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var version = "7.5.1";
    			var esHome = Environment.ExpandEnvironmentVariables($@"%LOCALAPPDATA%\ElasticManaged\{version}\elasticsearch-{version}");
    
    			using (var node = new ElasticsearchNode(version, esHome))
    			{
    				node.SubscribeLines(new LineHighlightWriter());
    				if (!node.WaitForStarted(TimeSpan.FromMinutes(2))) throw new Exception();
                    // do your work here
    			}
    		}
    	}
    }
