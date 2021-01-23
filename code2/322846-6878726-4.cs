	public interface IPizza
	{
		void Prepare();
	}
	
	public class StuffedCrustPizza : IPizza
	{
		public void Prepare()
		{
			// Set settings in system for stuffed crust preparations
		}
	}
	
	public class DeepDishPizza : IPizza
	{
		public void Prepare()
		{
			// Set settings in system for deep dish preparations
		}
	}
