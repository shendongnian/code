    var results= from a in previousQuery
                 join b in dtCounties.AsEnumerable()
                 on new { a.CountyCode, a.StateCode } equals new 
                        { CountryCode = b.Field<string>("COUNTYCODE") ,
                          StateCode = b.Field<string>("StateCode") }
                 where b.Field<bool>("TrueOrFalse") == true
                 select new
                 {
                        CountyCode = a.CountyCode,
                        TrueOrFalse= b.Field<bool>("TrueOrFalse"),
                        Sum= a.Sum
                 };
