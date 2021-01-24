using System;
using Autofac;
using Autofac.Features.AttributeFilters;
public class Program
{
	public interface IHello
	{
		 string Greetings { get; }
	}
	
	public class Hello : IHello
	{
		public string Greetings
		{
			get;
			set;
		}
	}
	
	public class HelloConsumer
	{
		public HelloConsumer([KeyFilter("EN")] IHello hello)
		{
			Console.WriteLine(hello.Greetings);
		}
	}
	public static void Main()
	{
		ContainerBuilder cb = new ContainerBuilder();
		cb.RegisterType<HelloConsumer>().AsSelf().WithAttributeFiltering();
		var helloEn = new Hello { Greetings = "Hi" };
		var helloFr = new Hello { Greetings = "Bonjour" };
		cb.Register<Hello>(x => helloEn).Keyed<IHello>("EN");
		cb.Register<Hello>(x => helloFr).Keyed<IHello>("FR");
		var container = cb.Build();
		
		container.Resolve<HelloConsumer>(); // Should write the correct greeting
	}
}
Fiddle: https://dotnetfiddle.net/3s6oFc
