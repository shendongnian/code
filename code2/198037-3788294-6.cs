string query = string.Format(
@"using (var dc = new DataContext()) 
{
  return (from contact in dc.Contacts where contact.Name == ""{0}"" select contact).ToList();
}", "John");
var result = Mono.CSharp.Evaluator.Evaluate(query);
