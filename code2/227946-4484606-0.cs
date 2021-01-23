    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
               
        public PriorityWrapper Priority { get; set; }
    }    
    public class PriorityWrapper
    {
        private Priority _t;
        public int Value
        {
            get
            {
                return (int)_t;
            }
            set
            {
                _t = (Priority)value;
            }
        }
        public Priority EnumValue
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }
    }
    public enum Priority
    {
        High,
        Medium,
        Low
    }
