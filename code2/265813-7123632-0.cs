    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System.Drawing;
    namespace Excel_Report
    {
        public partial class MReport : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        private void ExcelOut(DataTable tbl)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                string DocName = "A_Report_" + DateTime.Now;
                DocName = DocName.Replace("/", "_").Replace(" ", "_");
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DocName);
                //Load the datatable into the sheet, starting from cell A1. Print the     column names on row 1
                ws.Cells["A1"].LoadFromDataTable(tbl, true);
                ws.Cells[ws.Dimension.Address].AutoFitColumns(); ;
                //Format the header for column A-Z
                using (ExcelRange rng = ws.Cells["A1:U1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }
                //Write it back to the client
                byte[] renderedBytes;
                renderedBytes = pck.GetAsByteArray();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + DocName + ".xlsx");
                Response.BinaryWrite(renderedBytes);
                Response.End();
            }
        }
        //This is the Save Report Click event
        protected void Save_RPT_BTN_Click(object sender, EventArgs e)
        {
            //Finding my GridView, so on your blank.aspx page create a Gridview 
            ContentPlaceHolder ContentPH = (ContentPlaceHolder)Master.FindControl("Main_CPH_01");
            GridView gridView001 = (GridView)ContentPH.FindControl("GridView1");
            
            //This tells the GridView to grab its Data from its DataSource 
            gridView001.DataBind();
            //Create a new DataTable to save the GridView's data
            DataTable RPT_DT01 = new DataTable();
            
            //Create a connection string and a query string both of which are using parts of a SqlDataSource that belong to the GridView
            string aConnString = SqlDataSource1_RPT.ConnectionString.ToString();
            string queryString = SqlDataSource1_RPT.SelectCommand.ToString();
            
            //Set the properties to connect to your database
            using (SqlConnection connection =
                       new SqlConnection(aConnString))
            {
            // Set the properties for the database query
                SqlCommand command =
                    new SqlCommand(queryString, connection);
            //Open a connection to the database
                connection.Open();
            
           //Create a Sql Reader
                SqlDataReader reader01 = command.ExecuteReader();
                if (connection.State == ConnectionState.Open)
                {
                    // Call Read before accessing data.
                    reader01.Read();
                    
                    // Load the datatable with the data from the Sql reader
                    RPT_DT01.Load(reader01);
         
                    //Create the Excel File from the Data table
                    ExcelOut(RPT_DT01);
                    // Call Close when done reading.
                    reader01.Close();
                }
            }
        }
        }
    }
