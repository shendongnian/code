public class GraphQLQuery
{
    public string OperationName { get; set; }
    public string NamedQuery { get; set; }
    public string Query { get; set; }
    public JObject Variables { get; set; }
}
This class defines the Query and Variables properties you are trying to set.  You will then pass this object to make your query.
The code in your API controller would look something like this:
public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
{
    var inputs = query.Variables.ToInputs();
    var result = await new DocumentExecuter().ExecuteAsync(_ =>
                 {
                    _.Schema = productSchema;
                    _.Query = query.Query;
                    _.OperationName = query.OperationName;
                    _.Inputs = inputs;
                 }).ConfigureAwait(false);
    return Ok(result);
}
Source of implementation for more information: https://github.com/JacekKosciesza/StarWars
