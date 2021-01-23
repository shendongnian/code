	public abstract class MenuItem {
		public string Name { get; set; }
		public abstract void BringToTable();
	}
    // Notice Soda only inherits from MenuItem
    public class Soda : MenuItem {
        public override void BringToTable() { /* Bring soda to table */ }
    }
    // All food needs to be cooked (real food) so we add this
    // feature to all food menu items
	public interface IFood {
		void Cook();
	}
	public class Pizza : MenuItem, IFood {
		public override void BringToTable() { /* Bring pizza to table */ }
		public void Cook() { /* Cook Pizza */ }
	}
	public class Burger : MenuItem, IFood {
		public override void BringToTable() { /* Bring burger to table */ }
		public void Cook() { /* Cook Burger */ }
	}
