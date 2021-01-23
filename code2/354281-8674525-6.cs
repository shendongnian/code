	using Microsoft.Practices.ServiceLocation; // ServiceLocator , http://commonservicelocator.codeplex.com/
	using MyOwnRepositoryNameSpace; // IRepository
	public class EditViewModel
	{
		public int? FooType { get; set; }
		public IEnumerable<int?> FooTypes
		{
			get
			{
				return Repository.GetFooTypes();
			}
		}
		
		private IRepository Repository
		{
			get
			{
				return ServiceLocator.Current.GetInstance<IRepository>();
			}
		}	
	}
