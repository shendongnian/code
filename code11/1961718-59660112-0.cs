`
public class StudentRecord
{
    [Key]
    public Int ID { get; set; }
    public String StudentName { get; set; }
    [JsonIgnore]
    public String PropertyToIgnore{ get; set; }
}
