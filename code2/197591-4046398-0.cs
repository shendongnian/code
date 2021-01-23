    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Data;
    
    namespace Detectent.Analyze.ActionResults
    {
        public class CSVResult : ActionResult
        {
            /// <summary>
            /// Converts the columns and rows from a data table into an Microsoft Excel compatible CSV file.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="fileName">The full file name including the extension.</param>
            public CSVResult(DataTable dataTable, string fileName)
            {
                Table = dataTable;
                FileName = fileName;
            }
    
            public string FileName { get; protected set; }
            public DataTable Table { get; protected set; }
    
            
    
    
            public override void ExecuteResult(ControllerContext context)
            {
                StringBuilder csv = new StringBuilder(10 * Table.Rows.Count * Table.Columns.Count);
    
                for (int c = 0; c < Table.Columns.Count; c++)
                {
                    if (c > 0)
                        csv.Append(",");
                    DataColumn dc = Table.Columns[c];
                    string columnTitleCleaned = CleanCSVString(dc.ColumnName);
                    csv.Append(columnTitleCleaned);
                }
                csv.Append(Environment.NewLine);
                foreach (DataRow dr in Table.Rows)
                {
                    StringBuilder csvRow = new StringBuilder();
                    for(int c = 0; c < Table.Columns.Count; c++)
                    {
                        if(c != 0)
                            csvRow.Append(",");
    
                        object columnValue = dr[c];
                        if (columnValue == null)
                            csvRow.Append("");
                        else
                        {
                            string columnStringValue = columnValue.ToString();
                            
    
                            string cleanedColumnValue = CleanCSVString(columnStringValue);
                            
                            if (columnValue.GetType() == typeof(string) && !columnStringValue.Contains(","))
                            {
                                cleanedColumnValue = "=" + cleanedColumnValue; // Prevents a number stored in a string from being shown as 8888E+24 in Excel. Example use is the AccountNum field in CI that looks like a number but is really a string.
                            }
                            csvRow.Append(cleanedColumnValue);
                        }
                    }
                    csv.AppendLine(csvRow.ToString());
                }
    
                HttpResponseBase response = context.HttpContext.Response;
                response.ContentType = "text/csv";
                response.AppendHeader("Content-Disposition", "attachment;filename=" + this.FileName);
                response.Write(csv.ToString());
            }
    
            protected string CleanCSVString(string input)
            {
                string output = "\"" + input.Replace("\"", "\"\"").Replace("\r\n", " ").Replace("\r", " ").Replace("\n", "") + "\"";
                return output;
            }
        }
    }
