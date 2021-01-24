    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(FILENAME);
                DataTable table = ds.Tables[0];
                string[] columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                string query = string.Format("Select {0} FROM {1}", string.Join(",", columnNames), table.TableName);
            }
        }
    }
