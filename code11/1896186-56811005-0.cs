    public class PointPropertyDto
    {
        public string DataPointType { get; set; }
        public PointTypePropertyDto[] PointTypeProperties { get; set; }
    }
    public class PointTypePropertyDto
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string Requirement { get; set; }
    }
