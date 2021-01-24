using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Extensions;
    public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //...
            var querystring = QueryHelpers.ParseQuery(context.HttpContext.Request.QueryString.Value);
            var items = querystring.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
            var endDate = items.FirstOrDefault(q => q.Key == "Enddate" && q.Value.Contains("?culture=de"));
            if (!string.IsNullOrEmpty(endDate.Value))
            {
                items.Remove(endDate);
                var newEndDateValue = endDate.Value.Replace("?culture=de", "");
                var qb = new QueryBuilder(items);
                qb.Add("Enddate", newEndDateValue);
                Uri currentUrl = new Uri(HttpContext.Request.GetDisplayUrl());
                var url = String.Format("{0}{1}{2}{3}", currentUrl.Scheme,Uri.SchemeDelimiter, currentUrl.Authority, currentUrl.AbsolutePath);
                Response.Redirect(url.ToString() + "?" + qb.ToQueryString());
            }
        }
