public class Base
{
}
public class Operation : Base
{
    public string @operator { get; set; }
    public List<Base> rules { get; set; }
}
public class Rule : Base
{
    public string field { get; set; }
    public string condition { get; set; }
    public object value { get; set; }
}
Operation op = new Operation
{
    @operator = "AND",
    rules = new List<Base>
    {
        new Rule { field = "ENTITY.CIFNumber", condition = "<>", value = "3123" },
        new Rule { field = "ENTITY.Country", condition = "LIKE", value = "USA" },
        new Operation { @operator = "OR", rules = new List<Base>
                                                    {
                                                        new Rule { field = "ENTITY.FYEMonth", condition = "=", value = "May" },
                                                        new Rule { field = "STATEMENT.ProfitBeforeTax", condition = ">=", value = 123123 },
                                                        new Rule { field = "STATEMENT.NetSales", condition = "<=", value = 234234 },
                                                        new Rule { field = "STATEMENT.statementdatekey_", condition = "=", value = new DateTime(2019, 7, 1, 12, 0, 0) }
                                                    }
                      }
    }
};
string json = JsonConvert.SerializeObject(op, Formatting.Indented);
The generated json
{
  "operator": "AND",
  "rules": [
    {
      "field": "ENTITY.CIFNumber",
      "condition": "<>",
      "value": "3123"
    },
    {
      "field": "ENTITY.Country",
      "condition": "LIKE",
      "value": "USA"
    },
    {
      "operator": "OR",
      "rules": [
        {
          "field": "ENTITY.FYEMonth",
          "condition": "=",
          "value": "May"
        },
        {
          "field": "STATEMENT.ProfitBeforeTax",
          "condition": ">=",
          "value": 123123
        },
        {
          "field": "STATEMENT.NetSales",
          "condition": "<=",
          "value": 234234
        },
        {
          "field": "STATEMENT.statementdatekey_",
          "condition": "=",
          "value": "2019-07-01T12:00:00"
        }
      ]
    }
  ]
}
