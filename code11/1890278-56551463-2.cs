	internal class Module : NinjectModule
	{
		public override void Load()
		{
			Bind<IAnimal>().To<Bird>().WhenTargetHas<BirdAttribute>();
			Bind<IAnimal>().To<Monkey>().WhenTargetHas<MonkeyAttribute>();
		}
	}
