[DataContract]
public class Currency
{
    [DataMember(Name = "date")]
    public int Date { get; set; }
    [DataMember(Name = "price")]
    public double Price { get; set; }
    [DataMember(Name = "low")]
    public string Low { get; set; }
    [DataMember(Name = "high")]
    public string High { get; set; }
    [DataMember(Name = "nicedate")]
    public string NiceDate { get; set; }
}
