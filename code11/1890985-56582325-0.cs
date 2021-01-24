c#
public class ApiModel
{
    [Required]
    [Display(Name = "Index")]
    public string Index { get; set; }
    [Required]
    [Display(Name = "Type")]
    public string Type { get; set; }
    [Required]
    [Display(Name = "Id")]
    public string Id { get; set; }
    public dynamic Body { get; set; }
    public string sent_body { get; set; }
    public bool Request { get; set; }
    public string Method { get; set; }
    public string Rody { get; set; }
    public string Query { get; set; }
}
