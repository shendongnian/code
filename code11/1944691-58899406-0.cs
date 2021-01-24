          public DataTable numOfCalls(DataTable table)
        {
            //Initialize Result Table
            DataTable numOfCallsTable = new DataTable();
            numOfCallsTable.Columns.Add("agentName", typeof(string));
            numOfCallsTable.Columns.Add("numOfCall", typeof(int));
            // Get the unique agents
            DataView view = new DataView(table);
            DataTable distinctValues = view.ToTable(true, "agentName");
            // Check if there are agents
            if (distinctValues.Rows.Count > 0)
            {
                // Loop thru the agents
                for (int i = 0; i < distinctValues.Rows.Count; i++)
                {
                    string agentName = distinctValues.Rows[i]["agentName"].ToString();
                    // Get all the rows that this agent has
                    DataRow[] agentRows = table.Select($"agentName='{agentName}'");
                    // And then fill the second table
                    DataRow newRow = numOfCallsTable.NewRow();
                    newRow["agentName"] = agentName;
                    newRow["numOfCall"] = agentRows.Length;
                    numOfCallsTable.Rows.Add(newRow);
                }
            }
            return numOfCallsTable;
        }
