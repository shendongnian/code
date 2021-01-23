    public class SuperCar: Car
    {
         public bool SuperWheels { get {return true; } }
    
         Car carInstance = null;
         public void SetCar( Car car )
         {
             carInstance = car; 
         }
    }
