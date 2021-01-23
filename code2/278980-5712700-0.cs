            DataRow myRow;
            DataTable ACHFile = new DataTable();
            DataColumn EmpID = new DataColumn("EmpID", System.Type.GetType("System.String"));
            ACHFile.Columns.Add(EmpID );
        for (int i = 0; i < chkcnt; i++)
        {
            myRow = ACHFile.NewRow();
            myRow["EmpID"] = EmpID[i];
            ACHFile.Rows.Add(myRow);
    .......
        }
