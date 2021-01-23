    HqlBasedQuery query = new HqlBasedQuery(typeof(AccountRecord),
        "SELECT a, s, COUNT(p), MIN(p.DateUTC), MAX(p.DateUTC) " +
        "FROM AccountRecord a " +
        "LEFT JOIN a.Schools s " +
        "LEFT JOIN a.Users u " +
        "LEFT JOIN u.Points p " +
        "WHERE a.PaymentType=:payment GROUP BY a.Id");
    query.SetParameter("payment", "S");
    var result = from object[] row in (ArrayList)ActiveRecordMediator.ExecuteQuery(query)
                    select new
                    {
                        Account = row[0] as AccountRecord,
                        School = row[1] as SchoolRecord,
                        Count = row[2],
                        First = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(Convert.ToDouble(row[3])),
                        Last = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(Convert.ToDouble(row[4]))
                    };
