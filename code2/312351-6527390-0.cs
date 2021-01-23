    public abstract class Car
    {
         public bool isServiced;
         public string serviceMessage;
    
         public abstract string TypeName { get; }
         public virtual void SendToService()
         {
              Dealer.ServiceCar(this);       // error here when Definition 1 used
              servicesMessage = string.Format("Your {0} is clean.", Car.TypeName);
         }
     }
    
     public class Ford: Car
     {
          public override string TypeName { get { return "Ford"; } }
          //No need to override this because Ford inherits from Car
          //public override void SendToService()
          //{
          //     Dealer.ServiceCar<Ford>(this);
          //     serviceMessage = "Your Ford is clean.";
          //}
     }
    
     public class Dealer
     {
          public static void ServiceCar(Car carToService)
          {
               carToService.isServiced = true;
          }
     }
