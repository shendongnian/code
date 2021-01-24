    public class Ponds {
        public string Imei {get;set}
        [ForeignKey(nameof(Imei))]
        public virtual CustomerDevice Device {get;set;}
    }
    public class CustomerDevices {
        [Key]
        public string Imei {get;set}
        public int CustomerId {get;set;}
        public int DeviceId {get;set;}
        [ForeignKey(nameof(CustomerId))]
        public virtual User Customer {get;set;}
    }
    public class Users { 
        [Key]
        public int CustomerId {get;set;}
    }
