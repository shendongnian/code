	// @nuget: Autofac
	using System;
	using Autofac;
	public class Program
	{
		private static IContainer _container;
		public static void Main()
		{
			RegisterAutofac();
			using (var httpRequestScope = _container.BeginLifetimeScope("AutofacWebRequest"))
			{
				var apiController = httpRequestScope.Resolve<ApiFileSendingController>();
				Console.WriteLine(apiController._apiFileTester);
			}
		}
		public static void RegisterAutofac()
		{
			var builder = new ContainerBuilder();
			//builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterType<ApiFileTester>().As<IApiFlTester>().InstancePerLifetimeScope();
			builder.RegisterType<ApiFileSendingController>().AsSelf();
			builder.RegisterType<DTO>().AsSelf();
			_container = builder.Build();
		}
		public class ApiFileSendingController : ApiClientBase
		{
			public readonly IApiFlTester _apiFileTester;
			public ApiFileSendingController(DTO dto, IApiFlTester tester): base (dto)
			{
				_apiFileTester = tester;
			}
		}
		public interface IApiFlTester { }
		public class ApiFileTester : IApiFlTester { }
		public class ApiClientBase 
		{
			public ApiClientBase(DTO dto)
			{
			}
		}
		public class DTO { }
	}
