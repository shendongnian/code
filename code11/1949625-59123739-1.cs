    DataTable new_Table = new DataTable();
            new_Table.Columns.Add("Name");
            new_Table.Columns.Add("Salary");
            new_Table.Columns.Add("Date");
            new_Table.Columns.Add("Description");
            var groupedByState = old_datatable.AsEnumerable()
                .GroupBy(r => r.Field<String>("Name"));
            foreach (var group in groupedByState)
            {
                DataRow maxPremRow = group.OrderByDescending(r => r.Field<String>("Name")).First();
                DataRow newRow = new_Table.Rows.Add();
                newRow.SetField("id_po", group.Key);
                newRow.SetField("Status", maxPremRow.Field<string>("Status"));
                newRow.SetField("Cost_ex", group.Sum(r => r.Field<double?>("Cost_ex")));
                newRow.SetField("Name", maxPremRow.Field<string>("Name"));
                newRow.SetField("Salary", group.Sum(r => r.Field<double?>("Cost_ex")));
                newRow.SetField("Description", maxPremRow.Field<string>("Description"));
                newRow.SetField("Date", maxPremRow.Field<string>("Date"));
            }
