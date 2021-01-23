    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Diagnostics;
    using System.Data;
    
    namespace WebApplication2
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Debugger.Break();
                }
                else
                {
                    Debugger.Break();
                }
    
                DataTable oDataTable = new DataTable();
                oDataTable.Columns.Add("animal");
                DataRow oDataRow = oDataTable.NewRow();
                oDataRow["animal"] = "cat";
                oDataTable.Rows.Add(oDataRow);
    
                GridView1.Columns.Clear();
    
                ButtonField cf = new ButtonField();
                cf.HeaderStyle.CssClass = "comGridHeadCell";
                cf.HeaderText = "some text";
                cf.HeaderImageUrl = "images/something.png";
                cf.Text = "action";
                cf.CommandName = "action";
                cf.ImageUrl = "images/something.png";
                cf.ButtonType = ButtonType.Image;
                cf.ItemStyle.CssClass = "comGridLink";
    
                GridView1.Columns.Add(cf);
    
                GridView1.DataSource = oDataTable;
                GridView1.DataBind();
            }
    
    
            protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
    
            }
    
            protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                Debugger.Break();
            }
        }
    }
