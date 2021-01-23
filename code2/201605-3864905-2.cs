     public abstract class Policy {
         public string Description { get; set; }
         public abstract string Summary { get; }
     }
     public class MotorPolicy: Policy {
         public override string Summary {
             get { return this.Description + "\r\n" + this.Reg; }
         }
     }
     public class HouseholdPolicy: Policy {
         public override string Summary {
             get { return this.Description + "\r\n" + this.Contents; }
         }
     }
