    public class SupplierMaterialMaintenance : IComparable<SupplierMaterialMaintenance>, IEquatable<SupplierMaterialMaintenance>
    {
        public Guid SupplierMaterialAssociationGuid { get; set;}
        public int MinimumOrderQuantity { get; set;}
        public Guid UnitOfMeasurementGuid { get; set;}
        public int ConversionFactor { get; set;}
    //goes like this...
