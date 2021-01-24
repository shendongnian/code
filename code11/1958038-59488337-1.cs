    DataTable dt=new DataTable();
    dt.Columns.Add("SiteName",typeof(string));
    dt.Columns.Add("CountryName",typeof(string));
    dt.Rows.Add("ABC","India");
    dt.Rows.Add("ABC","China");
    dt.Rows.Add("DEF","Japan");
    dt.Rows.Add("DEF","Pakistan");
    dt.Rows.Add("DEF","Italy");
    var results = dt.AsEnumerable()
                  .GroupBy(x => x.Field<string>("SiteName"))
                  .Select(x => new { siteName = x.Key, countries = string.Join(",", x.Select(y => y.Field<string>("CountryName")))})
                  .ToList();
