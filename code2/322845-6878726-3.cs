	public class Pizza()
	{
		public void Prepare(PizzaType tp)
		{
			switch (tp)
			{
				case PizzaType.StuffedCrust:
					// prepare stuffed crust ingredients in system
					break;
					
				case PizzaType.DeepDish:
					// prepare deep dish ingredients in system
					break;
					
				//.... etc.
			}
		}
	}
