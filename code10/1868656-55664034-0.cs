    DataTable dttable = new DataTable();
    
    dttable.Columns.Add("billno", typeof(String));
    dttable.Columns.Add("date", typeof(DateTime));
    dttable.Columns.Add("time", typeof(String));
    dttable.Columns.Add("sname", typeof(String));
    dttable.Columns.Add("name", typeof(String));
    dttable.Columns.Add("qty", typeof(Decimal));
    dttable.Columns.Add("rate", typeof(Decimal));
    
    var rows = from mobjbmast in Context.bmasts.AsEnumerable()
               join mobjbtran in odlsContext.btrans
               on mobjbmast.billno equals mobjbtran.billno
               join mobjwaiter in Context.waiters
               on mobjbmast.scode equals mobjwaiter.code
               where mobjbmast.billno == mbillno
               let billarray = new object[]
               {
                    mobjbmast.billno,
                    mobjbmast.date,
                    mobjbmast.time,
                    mobjwaiter.name,
                    mobjbtran.name,
                    mobjbtran.qty,
                    mobjbtran.rate
               }
               select billarray;
    foreach (var array in rows)
    {
        dttable.Rows.Add(array);
    }
