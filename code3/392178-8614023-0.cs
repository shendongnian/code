	class Fruit{
		public void eat(){
			MessageBox.Show("Fruit eaten");
		}
		public string color = "red";
		public PhysicalProperties physicalProperties {get;set;}
		public class PhysicalProperties{
			public int height = 3;
		}
	}
