    [Table("OecPreorden")]
        [DataContract]
        public partial class OecPreorden
        {
            public OecPreorden()
            {
                OecPreordenProductos = new HashSet<OecPreordenProductos>();
            }
           [DataMember(IsRequired = false, Order = 1, Name = "ProductosComerciales")]
           [XmlArrayItem("AAA")]
            public virtual ICollection<OecPreordenProductos> OecPreordenProductos { get; set; }
      }
