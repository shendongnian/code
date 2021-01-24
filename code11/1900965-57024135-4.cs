	// @nuget: Autofac
	using System;
	using Autofac;
	public class Program
	{
		private static IContainer _Container;
		public static void Main()
		{
			var builder = new ContainerBuilder();
			builder
				.RegisterGeneric(typeof (Impl1<, >))
				.Named("pass string1", typeof (Calculator3rdParty<, >))
				.InstancePerLifetimeScope();
			builder
				.RegisterGeneric(typeof (Impl2<, >))
				.Named("pass string2", typeof (Calculator3rdParty<, >))
				.InstancePerLifetimeScope();
			_Container = builder.Build();
			using (var scope = _Container.BeginLifetimeScope())
			{
				var c3p = scope
                    .ResolveNamed<Calculator3rdParty<string, Model1>>("pass string2");
                // specify type at resolve ----------^
				Console.WriteLine(c3p.GetType());
			}
		}
	}
	public interface Calculator3rdParty<T1, T2>{}
	public class Model1{}
	public class Model2{}
	public class Impl1<T1, T2> : Calculator3rdParty<T1, T2>{}
	public class Impl2<T1, T2> : Calculator3rdParty<T1, T2>{}
