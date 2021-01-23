    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Net;
...
    public DataSet ExcelToDataSet(string excelFilename)
    {
        var dataSet = new DataSet(excelFilename);
        // Setup Connection string based on which excel file format we are using
        var excelType = "Excel 8.0";
        if (excelFilename.Contains(".xlsx"))
        {
            excelType = "Excel 12.0 XML";
        }
        // <add key="Microsoft.ACE.OLEDB" value="Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='{1};HDR=YES;READONLY=TRUE'"/>
        var connectionStringFormat = ConfigurationManager.AppSettings["Microsoft.ACE.OLEDB"].ToString();
        var excelNamePath = string.Format(@"{0}\{1}", Environment.CurrentDirectory, excelFilename);
        var connectionString = string.Format(connectionStringFormat, excelNamePath, excelType);
        // Create a connection to the excel file
        using (var oleDbConnection = new OleDbConnection(connectionString))
        {
            // Get the excel's sheet names
            oleDbConnection.Open();
            var schemaDataTable = (DataTable)oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            oleDbConnection.Close();
            var sheetsName = GetSheetsName(schemaDataTable);
            // For each sheet name 
            OleDbCommand selectCommand = null;
            for (var i = 0; i < sheetsName.Count; i++)
            {
                // Setup select command
                selectCommand = new OleDbCommand();
                selectCommand.CommandText = "SELECT * FROM [" + sheetsName[i] + "]";
                selectCommand.Connection = oleDbConnection;
                // Get the data from the sheet
                oleDbConnection.Open();
                using (var oleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    // Convert data to DataTable
                    var dataTable = new DataTable(sheetsName[i].Replace("$", "").Replace("'", ""));
                    dataTable.Load(oleDbDataReader);
                    // Add to Dataset
                    dataSet.Tables.Add(dataTable);
                }
            }
            return dataSet;
        }
    }
    private List<string> GetSheetsName(DataTable schemaDataTable)
    {
        var sheets = new List<string>();
        foreach(var dataRow in schemaDataTable.AsEnumerable())
        {
            sheets.Add(dataRow.ItemArray[2].ToString());
        }
        return sheets;
    }
