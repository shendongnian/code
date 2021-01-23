    var varResult =
        (from OppData in dtOpp.AsEnumerable()
          select new
          {
           TEXT = Convert.ToDateTime(OppData.Field<object>(sColName)).ToShortDateString(), //column value
           VALUE = sColName // column Name
           }
        ).Distinct();
