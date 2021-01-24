var results = new List<Result>();
results.Add(new Result() { Month = "January", Total = 44, Store = "Refoil" });
results.Add(new Result() { Month = "January", Total = 242, Store = "Sustainable Salons" });
results.Add(new Result() { Month = "January", Total = 99, Store = "The Base Collective" });
results.Add(new Result() { Month = "February", Total = 37, Store = "Refoil" });
results.Add(new Result() { Month = "February", Total = 219, Store = "Sustainable Salons" });
results.Add(new Result() { Month = "February", Total = 122, Store = "The Base Collective" });
results.Add(new Result() { Month = "February", Total = 148, Store = "Watersco Australia" });
var transpose = results.GroupBy(x => x.Month).Select(x =>
{
    dynamic e = new ExpandoObject();
    
    e.Month = x.Key;
    
    var ed = e as IDictionary<string, object>;
    
    x.ToList().ForEach(y => ed.Add(y.Store, y.Total));
    
    return e;
});
Debug.WriteLine(JsonConvert.SerializeObject(transpose, Newtonsoft.Json.Formatting.Indented));
Gives:-
[
  {
    "Month": "January",
    "Refoil": 44,
    "Sustainable Salons": 242,
    "The Base Collective": 99
  },
  {
    "Month": "February",
    "Refoil": 37,
    "Sustainable Salons": 219,
    "The Base Collective": 122,
    "Watersco Australia": 148
  }
]
