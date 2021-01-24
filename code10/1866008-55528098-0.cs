            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Rows.Add(1, "Mike");
            dataTable.Rows.Add(2, "Cris");
            dataTable.Rows.Add(3, "Ann");
            var _selector = dataTable.Rows.Cast<DataRow>().Select(x => x.Field<int>("ID")).ToList();
            ArrayList list = new ArrayList(_selector);
