class ModelA 
{
    public Id {get; set;}
    [ForeignKey("ModelB")]
    public int? ModelBId { get; set; }
    public ModelB ModelB { get; set; }
}
or
class ModelA 
{
    public Id {get; set;}
    public int? ModelBId { get; set; }
    [ForeignKey("ModelBId")]
    public ModelB ModelB { get; set; }
}
