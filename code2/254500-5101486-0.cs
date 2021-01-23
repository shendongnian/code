      public partial class Employee
       {
         public void Detach()
         {
           this.PropertyChanged = null; this.PropertyChanging = null;
           // Assuming there's a foreign key from Employee to Boss
           this.Boss = default(EntityRef<Boss>);
           // Similarly set child objects to default as well
           this.Subordinates = default(EntitySet<Subordinate>);
         }
      }
