    public SomethingModel : EntitydataModelBase<Something> {
         ................
         public Order Order {
             get {
                 return this.Entity.Order;
             }
             set {
                 if (this.Entity.Order == value) return;
                 this.Entity.Order = value;
                 NotifyPropertyChanged("Order");
             }
         }
         ................
    }
