	public interface IWalkable
	{
    	string Walk();
	}
	
	public interface IHuntable
	{
    	string Hunt();
	}
	
	public interface IHibernatable
	{
    	string Hibernate();
	}
		
	
	public interface IAnimal: IWalkable, IHuntable, IHibernatable
	{    	
		string SomeCommonAnimalFunction();
	}
	
	public class Animal: IAnimal
	{
		private IWalkable walkableProvider = null;
		private IHuntable huntableProvider = null;
		private IHibernatable hibernatableProvider = null;
		
		Animal(IWalkable walkableProvider = null, IHuntable huntableProvider = null, IHibernatable hibernatableProvider = null) {
			this.walkableProvider = walkableProvider;
			this.hibernatableProvider = hibernatableProvider;
			this.huntableProvider = huntableProvider;
		}
		
		public string SomeCommonAnimalFunction() {
			return "SomeCommonAnimalFunctionResult";
		}
		
		public string Walk() {
			return walkableProvider == null ? "default walk" : walkableProvider.Walk();
		}
		
		public string Hunt() {
			return huntableProvider == null ? "default hunt" : huntableProvider.Hunt();
		}
		
		public string Hibernate() {
			return hibernatableProvider == null ? "default hibernate" : hibernatableProvider.Hibernate();
		}
	}
