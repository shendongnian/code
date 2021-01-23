    public class Waiter	{
		public void TakeOrder(IEnumerable<MenuItem> order) 
        {
			// Cook first
			foreach (var food in order.OfType<IFood>())
				food.Cook();
			// Bring them all to the table
			foreach (var menuItem in order)
				menuItem.BringToTable();
		}
	}
