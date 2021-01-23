    class Fruit{
        public void eat(){
            MessageBox.Show("Fruit eaten");
        }
        public string color = "red";
        public class physicalProperties{
            public int height = 3;
        }
        // create a new instance of the class so its public members
        // can be accessed
        public physicalProperties PhysicalProperties = new physicalProperties();
    }
