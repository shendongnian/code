    HqlBasedQuery query = new HqlBasedQuery(typeof(ActivationCodeTestaccountRequestRecord),
                "SELECT DISTINCT r.ActivationCodeId, YEAR(r.Requested), MONTH(r.Requested) " +
                "FROM ActivationCodeTestaccountRequestRecord r");
    var items = from object[] row in (ArrayList)ActiveRecordMediator.ExecuteQuery(query)
                group row by new { Year = row[1], Month =row[2] } into g2
                select new { Year = g2.Key.Year, Month = g2.Key.Month, Count = g2.Count() };
