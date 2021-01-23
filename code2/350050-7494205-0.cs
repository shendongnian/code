    [DataContractAttribute]
    public partial class ShapeEntity
    {
        [Key]
        [DataMemberAttribute()]
        public int Id { get; set; }
        [DataMemberAttribute()]
        public IEnumerable<SingleShapeEntity> ShapeEntities { get; set; }
    }
