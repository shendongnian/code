    var q = from up in UPs.Cast<int>()
            from myTime in DateExtraction.Cast<DateTime>()
            join r in SourceData.AsEnumerable() on 
              new { r.Field<int>("UP"), r.Field<int>("DateExtraction")} equals
              new { up, myTime }
            select new
            {
               Energy1 = r.Field<Decimal>("Energy1"),
               Energy2 = r.Field<Decimal>("Energy2")
            };
