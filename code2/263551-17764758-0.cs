    using System.Data;
    using System.Data.OleDb;
        static bool AceOleDb12Present()
        {
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataTable table = enumerator.GetElements();
            bool bNameFound = false;
            bool bCLSIDFound = false;
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    if ((col.ColumnName.Contains("SOURCES_NAME")) && (row[col].ToString().Contains("Microsoft.ACE.OLEDB.12.0")))
                        bNameFound = true;
                    if ((col.ColumnName.Contains("SOURCES_CLSID")) && (row[col].ToString().Contains("{3BE786A0-0366-4F5C-9434-25CF162E475E}")))
                        bCLSIDFound = true;
                }
            }
            if (bNameFound && bCLSIDFound)
                return true;
            else
                return false;
        }
