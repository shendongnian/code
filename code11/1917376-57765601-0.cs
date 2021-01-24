    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class WebForm3 : System.Web.UI.Page
        {
            string customColumn = string.Empty;
            protected void Page_Load(object sender, EventArgs e)
            {
                customColumn = "AAA";
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Dosage", typeof(int));
                table.Columns.Add("Drug", typeof(string));
                table.Columns.Add("Patient", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));
    
                // Here we add five DataRows.
                table.Rows.Add(25, "Indocin", "David", DateTime.Now);
                table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
                table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
                table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
                table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
    
    
                //Add new column  in gridview if its not set true for autogenerare columns
                //BoundField test = new BoundField();
                //test.DataField = "Country";
                //test.HeaderText = "Country";
                //GridView1.Columns.Add(test);
    
    
                //add  new column for your custom variable to datasource
                table.Columns.Add(new DataColumn("Country"));
    
    
                GridView1.DataSource = table;
                GridView1.DataBind();
    
            }
    
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //putting data in column Conditionaly 
                    if (Convert.ToDateTime(e.Row.Cells[3].Text)<DateTime.Now)
                    {
                        e.Row.Cells[4].Text = customColumn;
                    }
                }
            }
        }
    }
