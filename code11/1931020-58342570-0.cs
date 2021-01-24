`
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
    private DataTable _dt;
    private Collection<int> _rowsNeedUpdated;
    public void TestFunction()
    {
        string[] lines = File.ReadAllLines(Server.MapPath("~/Files/ImportData_TabDelimited.txt"), Encoding.UTF8);
        bool isFirstLine = true;
        foreach (string line in lines)
        {
            if (isFirstLine)
            {
                string[] headers = line.Split('\t');
                foreach (string header in headers)
                {
                    // dont want any whitespaces
                    _dt.Columns.Add(header.Replace(" ", ""));
                }
                isFirstLine = false;
                continue;
            }
            string[] items = line.Split('\t');
            DataRow row = _dt.NewRow();
            for (int i = 0; i < _dt.Columns.Count; i++)
            {
                row[_dt.Columns[i].ColumnName] = items[i];
            }
            _dt.Rows.Add(row);
        }
        // these are just methods of getting specific row data (similar to a SQL WHERE clause)
        DataRow[] rows = _dt.Select("ID_VARIAVEL = '5'");
        DataRow[] rows2 = _dt.Select(String.Format("ID_VARIAVEL LIKE '%{0}%' AND ANO = '1'", "formattedString"));
        for (int i = 0; i < _dt.Rows.Count; i++)
        {
            // get each datarow item
            // example
            string id = (string)_dt.Rows[i]["columnName"];
            // execute SQL query and check the return value based on my previous comments
            // if it needs to be updated, capture the row to update later
            _rowsNeedUpdated.Add(i);
        }
    }
`
