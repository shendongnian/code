public class Product {
    [Column("id")]
    public int Id { get; set; }//Map this as Identity.
    public uint IdCopy { get { return Convert.ToUInt32(Id); } }//Readonly; Exclude this from mapping
}
