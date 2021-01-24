        public ActionResult LoadData()
        {
            string query = "SELECT LastName,FirstName,PhoneNumber,Skype,Email,City FROM Contacts;;
            using (OdbcConnection c = new OdbcConnection(Connection.Conn()))
            {
                OdbcCommand cmd = new OdbcCommand(query, c);
                c.Open();
                OdbcDataReader dr = cmd.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(dr);
                var lst = dataTable.AsEnumerable()
                        .Select(r => r.Table.Columns.Cast<DataColumn>()
                                .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
                               ).ToDictionary(z => z.Key, z => z.Value)
                        ).ToList();
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
        }
I took this solution from https://stackoverflow.com/a/30899867/3816470.
I don't know more about Ajax Datable so I'll not for any help on this part.
