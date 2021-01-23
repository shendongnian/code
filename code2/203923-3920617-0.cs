    public class EntityA
    {
        public int EntityAId { get; set; }
        public virtual EntityB EntityB1 { get; set; }
        public virtual EntityB EntityB2 { get; set; }
        public virtual EntityB EntityB3 { get; set; }
    }
    public class EntityB
    {
        public int EntityBId { get; set; }
        public string Name { get; set; }
    }
