        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Data;
        using System.IO;
        using System.Data.OleDb;
        using System.Collections;
    namespace ImportFromExcelToGridViewWebApp
    {
        public partial class ImportFromExcelToDatasetAndGridviewAndExport : System.Web.UI.Page
        {
            private ArrayList ExcelData
            {
                get
                {
                    object excel = Session["dropdownvalue"];
                    if (excel == null) Session["dropdownvalue"] = new ArrayList();
                    return (ArrayList)Session["dropdownvalue"];
                }
                set
                {
                    Session["dropdownvalue"] = value;
                }
            }
            protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddl = (DropDownList)e.Row.FindControl("DrdDatabase");
                    foreach (string colName in ExcelData)
                        ddl.Items.Add(new ListItem(colName));
                }
            }
            protected void btnImport_Click(object sender, EventArgs e)
            {
                ArrayList alist = new ArrayList();
                string connString = "";
                string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
                string fileBasePath = Server.MapPath("~/Files/");
                string fileName = Path.GetFileName(this.fileuploadExcel.FileName);
                string fullFilePath = fileBasePath + fileName;
                //Connection String to Excel Workbook
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullFilePath +
                                  ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFilePath +
                                 ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
                }
                if (fileuploadExcel.HasFile)
                {
                    string query = "SELECT [UserName],[Education],[Location] FROM [Sheet1$]";
                    OleDbConnection conn = new OleDbConnection(connString);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //Assigning dataset table data to GridView Control
                    Session["griddata"] = ds.Tables[0];
                    System.Data.DataTable dtt = (System.Data.DataTable)Session["griddata"];  //griddata is the gridview data from another page        
                    var res = (from f in dtt.AsEnumerable()
                               select f.Field<string>("Location")
                        );
                    foreach (string s in res.AsEnumerable())
                    {
                        alist.Add(s);
                    }
                    Session["dropdownvalue"] = alist;
                    grvExcelData.DataSource = Session["griddata"];
                    grvExcelData.DataBind();
                    da.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
       
            protected void btnExport_Click(object sender, EventArgs e)
            {
                System.Data.DataTable dtExcel = new DataTable();
           
                dtExcel.Columns.Add("UserName", typeof(string));
                dtExcel.Columns.Add("Education", typeof(string));
                dtExcel.Columns.Add("Location", typeof(string));
                dtExcel.Columns.Add("Select", typeof(string));
                foreach (GridViewRow row in grvExcelData.Rows)
                {
                    string UserName = ((TextBox)row.FindControl("txtUserName")).Text;
                    string Education = ((TextBox)row.FindControl("txtEducation")).Text;
                    string Location = ((TextBox)row.FindControl("txtLocation")).Text;
                    string Location2 = ((DropDownList)row.FindControl("DrdDatabase")).Text;
                    DataRow dr = dtExcel.NewRow();
                    dr["UserName"] = UserName;
                    dr["Education"] = Education;
                    dr["Location"] = Location;
                    dr["Select"] = Location2;
                    dtExcel.Rows.Add(dr);
                }
                CreateWorkbook(dtExcel, Server.MapPath("~/DownlodedFiles/Excel.xls"));
            }
            public static void CreateWorkbook(System.Data.DataTable dtExcelData, String path)
            {
                int rowindex = 0;
                int columnindex = 1;
                Microsoft.Office.Interop.Excel.Application app;
                Microsoft.Office.Interop.Excel.Worksheet wksheet;
                Microsoft.Office.Interop.Excel.Workbook wkbook;
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                wkbook = app.Workbooks.Add(true);
                wksheet = (Microsoft.Office.Interop.Excel.Worksheet)wkbook.ActiveSheet;
                try
                {
                    for (int i = 0; i < dtExcelData.Columns.Count; i++)
                    {
                        wksheet.Cells[1, i + 1] = dtExcelData.Columns[i].ColumnName;
                    }
                    foreach (DataRow row in dtExcelData.Rows)
                    {
                        rowindex++;
                        columnindex = 0;
                        foreach (DataColumn col in dtExcelData.Columns)
                        {
                            columnindex++;
                            wksheet.Cells[rowindex + 1, columnindex] = row[col.ColumnName];
                        }
                    }
                    app.Visible = true;
                }
                catch (Exception ex1)
                {
                
                }
                app.UserControl = true;
            }
        }
    }
