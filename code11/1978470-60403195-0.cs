`
public class SymptomousInBodySublocations
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool HasRedFlag { get; set; }
    [NotMapped]
    public List<int> HealthSymptomLocationIDs { get; set; }
    public string ProfName { get; set; }
    [NotMapped]
    public List<string> Synonyms { get; set; }
}
`
