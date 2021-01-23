public static RouteValueDictionary QueryStringToRouteValueDictionary(this HtmlHelper html)
{
   var qs = html.ViewContext.RequestContext.HttpContext.Request.QueryString;
   return qs.AllKeys.Aggregate(new RouteValueDictionary(html.ViewContext.RouteData.Values),
    (rvd, k) =>
   {
     // get values
     var values = qs.GetValues(k);
     // if only one value simply add it
     if (values.Length == 1)
     {
       rvd.Add(k, values[0]);
     }
     else
     {
       // an array has to be add using the syntax <k>[<i>] for the key values, where k is the key itself and i is the counter
       for (var i = 0; i < values.Length; ++i)
       {
         rvd.Add($"{k}[{i}]", values[i]);
       }
     }
     return rvd;
  });
}
