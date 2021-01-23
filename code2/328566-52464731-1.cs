        public class SuperCar : Car
         {
          public string newProp {get;set}
           // and some more properties
          protected override void SetExtraProperties()
           {
           this.newProp = "";
            …
           }
         }
