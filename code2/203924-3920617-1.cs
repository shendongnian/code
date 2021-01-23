    public class EntityA
    {
        public int EntityAId { get; set; }
        public int MySpecialFkName { get; set; }
        [RelatedTo(ForeignKey = "MySpecialFkName")]
        public EntityB EntityB1 { get; set; }
    }
