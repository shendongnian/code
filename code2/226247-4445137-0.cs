    var xml = Generate<NewsProperty>();
    var mapping = XmlMappingSource.FromUrl(xml);
    var ctx = new DataContext(new SqlConnection("..."), mapping);
    var query = ctx.GetTable<NewsProperty>().Where(n => n.Date.Year == 2010).OrderBy(n => n.Date).Take(5);
    var cmd = ctx.GetCommand(query);
    string sql = cmd.CommandText;
     
    foreach (DbParameter param in cmd.Parameters)
    {
       sql = sql.Replace(param.ParameterName, param.Value.ToString());
    }
