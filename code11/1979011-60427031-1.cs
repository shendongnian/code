    public partial class IICustomer : IEntity
    {
        public IICustomer(){
            IItem= new IItem();
        }
        public int CreatedByEmployeeId { get; set; }
        public virtual IItem IItem { get; set; }
    }
