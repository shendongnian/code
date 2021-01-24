    using (var ctx = new MuleContext())
    {
        var query = 
            from b in ctx.tbl_brand
            select new
            {
                b.OID,
                NewsCount = ctx.tbl_result_subject_brand.Count(rs => rs.brand_id == b.OID)
            };
        var list = query.ToList();
    }
