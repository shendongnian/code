    public abstract class Entity<T>
        {
            [Browsable(false)]
            public int CreatedBy { get; set; }
            [DisplayName("Utworzył")]
            public string CreatedByName { get; set; }
            [DisplayName("Data utworzenia")]
            public DateTime CreatedOn { get; set; }
            [Browsable(false)]
            public int? LmBy { get; set; }
            [DisplayName("Zmodyfikował")]
            public string LmByName { get; set; }
            [DisplayName("Data modyfikacji")]
            public DateTime? LmOn { get; set; }
            [Browsable(false)]
            public int TenantId { get; set; }
            [Browsable(false)]
            public string TenantName { get; set; }
            public virtual void Add(){
    //operation using base properties
             }
    
    public class Car : Entity<Car>
        {
            public int CarId { get; set; }
            public override void Add(){
                //do custom operation or call base.Add() or whatever you want
            }
        }
    }
