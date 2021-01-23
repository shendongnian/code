    using System;
    using System.Data;
    using System.Threading;
    using System.Web.UI.WebControls;
    
    namespace TemplateGridViewNoDataSourcePagingSorting
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Thread.Sleep(3000); // simulate long response time
                    var ItemsDataSet = new DataSet();
                    ItemsDataSet.ReadXml(MapPath("Items.xml"));
                    Session["items"] = ItemsDataSet.Tables[0];
                    ViewState["sortingOrder"] = string.Empty;
                }
            }
    
            protected void ItemsGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                ItemsGV.PageIndex = e.NewPageIndex;
                ItemsGV.DataSource = Session["items"];
                ItemsGV.DataBind();
            }
    
            protected void ItemsSearch(object sender, EventArgs e)
            {
                ItemsGV.Visible = true;
                DataBindGrid("", "");
            }
    
            private void DataBindGrid(string sortExpr, string sortOrder)
            {
                // if sorting expression had changed
                // set sort order to ascending
                if (sortExpr != (string)ViewState["sortingExpression"])
                {
                    sortOrder = "asc";
                    ViewState["sortingOrder"] = "asc";
                }
                ViewState["sortingExpression"] = sortExpr;
    
                var dt = Session["items"] as DataTable;
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    if (sortExpr != string.Empty)
                        dv.Sort = sortExpr + " " + sortOrder;
                    ItemsGV.DataSource = dv;
                    ItemsGV.DataBind();
                }
                else
                {
                    ItemsGV.DataSource = null;
                    ItemsGV.DataBind();
                }
            }
    
            protected void ItemsGV_Sorting(object sender, GridViewSortEventArgs e)
            {
                DataBindGrid(e.SortExpression, sortingOrder);
            }
    
            public string sortingOrder
            {
                get
                {
                    if (ViewState["sortingOrder"].ToString() == "desc")
                        ViewState["sortingOrder"] = "asc";
                    else
                        ViewState["sortingOrder"] = "desc";
                    return ViewState["sortingOrder"].ToString();
                }
                set
                {
                    ViewState["sortingOrder"] = value;
                }
            }
        }
    }
