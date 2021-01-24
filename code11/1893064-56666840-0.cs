public class Geometria : IValidatableObject
{
    public int Id { get; set; }
    public string Componente { get; set; }
    [Range(0, float.MaxValue)]   
    public float ToleranciaInferior { get; set; }
    [Range(0,float.MaxValue)]
    public float ToleranciaSuperior { get; set; }     
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ToleranciaInferior == ToleranciaSuperior) 
        {
            yield return new ValidationResult(
                "Your error message", 
                new string[] { 
                    nameof(ToleranciaInferior), nameof(ToleranciaSuperior) 
                });
        }
    }
}
