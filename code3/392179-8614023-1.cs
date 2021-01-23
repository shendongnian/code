	class Fruit{
		public void eat(){
			MessageBox.Show("Fruit eaten");
		}
		public string color = "red";
		public class PhysicalProperties{
			public int height = 3;
		}
        // Add a field to hold the physicalProperties:
        public PhysicalProperties physicalProperties = new PhysicalProperties();
	}
