    [EnableClientAccess]
    public class ShapeEntity
    {
        [Key]
        public int Id { get; set; }
        [Association("Shapes", "Id", "Id")]
        [Include()]
        public IEnumerable<SingleShapeEntity> ShapeEntities { get; set; }
        public DateTime Updated { get; set; }
    }
