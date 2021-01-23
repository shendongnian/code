	using MyOwnRepositoryNameSpace; // IRepository
	public class EditViewModel
	{
		private readonly IRepository _repository;
		
		public EditViewModel(IRepository repository) 
		{
			_repository = repository;
		}
		
		public int? FooType { get; set; }
		public IEnumerable<int?> FooTypes
		{
			get
			{
				return _repository.GetFooTypes();
			}
		}
	}
