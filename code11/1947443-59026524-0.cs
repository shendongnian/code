    public class Child
    {
    [Key]
    public int ID { get; set; }
    public string Item { get; set; }
    [ForeignKey("ParentID")]
    public int ParentID { get; set; }
    public virtual Parent Items { get; set; }
    }
