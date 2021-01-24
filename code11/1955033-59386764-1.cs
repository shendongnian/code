    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebFormIdentityTest
    {
        public partial class GridviewWithDDL : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
    
            private void BindGrid()
            {
                DataTable d1 = new DataTable();
                d1.Columns.Add("id");
                d1.Columns.Add("Status");
                d1.Columns.Add("SelectSource");
                d1.Columns.Add("SourceName");
                d1.Rows.Add("1", "Present", "bbbb", "aaaaaaa");
                d1.Rows.Add("2", "Absent", "ccccc", "dddddd");
                d1.Rows.Add("3", "Leave", "dddd", "fffff");
                d1.Rows.Add("4", "aaaa", "eeee", "ffff");
                d1.Rows.Add("5", "Leave", "cccc", "asdasdas");
                d1.Rows.Add("6", "bbb", "werwer", "qweqwe");
                GridView1.DataSource = d1;
                GridView1.DataBind();
         
            }
    
    
            public static String statusConversion(object myVal)
            {
                String p = "Present";
                String a = "Absent";
                String l = "Leave";
                String val = myVal.ToString();
                if (val.Equals(a) || val.Equals(p))
                {
                    return val;
                }
                else
                {
    
                    val = l;
                    return val;
    
                }
            }
    
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
    
            }
    
            protected void GridView1_DataBound(object sender, EventArgs e)
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    if (gvRow.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddl = gvRow.FindControl("ddlStatus") as DropDownList;
                        HiddenField hf = gvRow.FindControl("HiddenField1") as HiddenField;
    
    
                        ddl.SelectedValue = statusConversion(hf.Value);
                    }
    
                 
    
                }
            }
        }
    }
