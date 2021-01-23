    public class Garage
    {
        private List<Car> Cars { get; set; }
    
        public Garage()
        {
           this.LoadCars();
        }
       
        private void LoadCars()
        {
           this.Cars = new List<Car>();
           this.Cars.Add( new Ferrari() );
           this.Cars.Add( new AstonMartin() );
        }
    
        public int GetMaxSpeedOfAllCars()
        {
            int maxSpeed = 0;
    
            foreach( Car car in this.Cars )
            {
                if( car.MaxSpeed > maxSpeed )
                {
                    maxSpeed = car.MaxSpeed;
                }
            }
    
            return maxSpeed;
        }
    
    }
