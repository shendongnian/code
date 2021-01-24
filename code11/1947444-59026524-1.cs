    public class Child
    {
    [Key]
    public int ID { get; set; }
    public string Item { get; set; }
    public int ParentID { get; set; }
    [ForeignKey("Parent")]
    public Parent Items { get; set; }
    }
