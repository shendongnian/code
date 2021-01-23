       public class Car
       {
          public string model {get;set}
          public int year {get;set}
          public void SetCarProperties(Car theCar)
          {
              //sets the properties for car here
             ….
            //at the end:
              SetExtraProperties();
           }
          protected virtual void SetExtraProperties()
          {
          }
      }
