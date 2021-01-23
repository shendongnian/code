	using System;
	using System.ServiceModel;
	using System.ServiceModel.Channels;
	using System.ServiceModel.Routing;
	using System.ServiceModel.Dispatcher;
	using System.ServiceModel.Description;
	namespace FSharpRouterInCSharp
	{
		class Program
		{
			static ServiceHost createSimpleRouter (Binding createBinding, string routerAddress, string serviceAddress)
			{
				var routerType = typeof (IRequestReplyRouter);
				var routerContract = ContractDescription.GetContract(routerType);
				//var endpoint = new ServiceEndpoint(routerContract, createBinding, new EndpointAddress(address));
				var serviceEndpoints = new ServiceEndpoint[] { new ServiceEndpoint(routerContract, createBinding, new EndpointAddress(serviceAddress))};
				var configuration = new RoutingConfiguration();
				configuration.FilterTable.Add(new MatchAllMessageFilter(), serviceEndpoints);
				var host = new ServiceHost(typeof (RoutingService));
				host.AddServiceEndpoint(routerType, createBinding, routerAddress);
				host.Description.Behaviors.Add(new RoutingBehavior(configuration));
				return host;
			}
			static void Main(string[] args)
			{
				string routerAddress = "net.tcp://localhost:4508/";
				string serviceAddress = "net.tcp://remotehost:4508/";
				var netTcp = new NetTcpBinding(SecurityMode.None);
				var mextTcp = MetadataExchangeBindings.CreateMexTcpBinding();
				
				var tcpRouter = createSimpleRouter(netTcp, routerAddress, serviceAddress);
				var mexRouter = createSimpleRouter(mextTcp,routerAddress+"mex",serviceAddress+"mex");
				tcpRouter.Open();
				mexRouter.Open();
				Console.WriteLine("routing ...\n{0} <-> R:{1}", serviceAddress, routerAddress);
				Console.ReadKey();
			}
		}
	}
