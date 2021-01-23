	public static T Save<T>(this T current)
	{
		var rep = IoCFactory.Current.Container.GetInstance<IRepository<T>>();
		rep.Save(current);
	}
