`
public class RuleValidation
{
    public int RuleId { get; set; }
    public string RuleName { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public List<RuleException> RuleExcpetions { get; set; } = new List<RuleException>();
}
`
There is an example [here](https://dapper-tutorial.net/result-multi-mapping#example-query-multi-mapping-one-to-many)
