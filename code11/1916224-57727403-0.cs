List<filterList> filterList //List to be used as filter
{
 "filterOne",
 "filterTwo",
 "filterN"
}
class Workorder //Database Model
{
 public string SiteId { get; set; }      
 public string Location { get; set; }        
}
static Expression<Func<T, bool>> GetExpression<T>(string propertyName, List<string> propertyValue)
{
 Expression orExpression = null;
 var parameterExp = Expression.Parameter(typeof(T), "type");
 var propertyExp = Expression.Property(parameterExp, propertyName);
 foreach (string searchTerm in propertyValue)
 {
  MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
  var someValue = Expression.Constant(searchTerm, typeof(string));
  var containsMethodExp = Expression.Call(propertyExp, method, someValue);
  if(orExpression == null) //to handle intial phase when left expression = null
  {
   orExpression = Expression.Call(propertyExp, method, someValue);
  }else
  {
   orExpression = Expression.Or(orExpression, containsMethodExp);
  }
  return Expression.Lambda<Func<T, bool>>(orExpression, parameterExp);
}
myQueryable = myQueryable.Where(GetExpression<Workorder>(property, filterList));
This Equals:
myQueryable = myQueryable.Where(filelist => filelist.Location.Contains(filterList[0]) || filelist.Location.Contains(filterList[1]) || filelist.Location.Contains(filterList[N])...);
