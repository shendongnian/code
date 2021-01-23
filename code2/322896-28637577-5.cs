    public class Waiter	{
		public void TakeOrder(IEnumerable<MenuItem> order) 
        {
			// Cook first
            // (all except soda because soda is not IFood)
			foreach (var food in order.OfType<IFood>())
				food.Cook();
			// Bring them all to the table
            // (everything, including soda, pizza and burger because they're all menu items)
			foreach (var menuItem in order)
				menuItem.BringToTable();
		}
	}
