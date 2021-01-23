            DataTable newTable = new DataTable();
            foreach (DataRow dr in oldTable.Select("EmpID = '0'")) {
                newTable.Rows.Add(dr);
                oldTable.Rows.Remove(dr);
            }
