    public class MembershipTypes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class NewCustomerviewModel
    {
        public int[] SelectMembershipTypesId { get; set; }
        public Customers Customers { get; set; }
    }
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
    }
