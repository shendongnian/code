        string query1String, query2String;
        using (var context = new TRANSITEntities())
        {
            var result = context.Table1.Where(c => c.UserCode == "123");
            query1String = result.Expression.ToString();
        }
        using (var context = new TRANSITEntities())
        {
            var result = from c in context.Table1
                         where c.UserCode == "123"
                         select c;
            var query2String = result.Expression.ToString();
        }
        Assert.AreEqual(query1String, query2String);
