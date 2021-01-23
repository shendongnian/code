        <html xmlns="http://www.w3.org/1999/xhtml">
        <head id="Head1" runat="server">
         <title>DataBase Driven Menu</title>
        
         </head>
         <body>
         <form id="form1" runat="server">
         <div id="myslidemenu" class="jqueryslidemenu">
         <asp:Menu ID="Menu1" runat="server" StaticEnableDefaultPopOutImage="False"
         Orientation="Horizontal" StaticSubMenuIndent="10px" BackColor="#FFFBD6"
         DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em"
         ForeColor="#990000">
         <DataBindings>
         <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Text"
         ToolTipField="ToolTip" />
         </DataBindings>
         <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
         <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
         <DynamicMenuStyle BackColor="#FFFBD6" />
         <DynamicSelectedStyle BackColor="#FFCC66" />
         <StaticHoverStyle BackColor="#990000" ForeColor="White" />
         <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
         <StaticSelectedStyle BackColor="#FFCC66" />
         </asp:Menu>
        
         </div>
         </form>
        </body>
        </html>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Xml;
    using System.Data;
     
    public partial class _Default : System.Web.UI.Page
    {
     
    protected void Page_Load(object sender, EventArgs e)
     {
     if (!IsPostBack)
     {
     DataSet ds = new DataSet();
     XmlDataSource xmlDataSource = new XmlDataSource();
     xmlDataSource.ID = "xmlDataSource";
     xmlDataSource.EnableCaching = false;
     
    string connStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=G:\Admin\WebSite28\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
     using (SqlConnection conn = new SqlConnection(connStr))
     {
     string sql = "Select ID, Text,NavigateUrl,ParentID from Menu";
     SqlDataAdapter da = new SqlDataAdapter(sql, conn);
     da.Fill(ds);
     da.Dispose();
     }
     
    &nbsp;
     
    ds.DataSetName = "Menus";
     ds.Tables[0].TableName = "Menu";
     DataRelation relation = new DataRelation("ParentChild",
     ds.Tables["Menu"].Columns["ID"],
     ds.Tables["Menu"].Columns["ParentID"],
     true);
     
    relation.Nested = true;
     ds.Relations.Add(relation);
     
    xmlDataSource.Data = ds.GetXml();
     
    //Reformat the xmldatasource from the dataset to fit menu into xml format
     xmlDataSource.TransformFile = Server.MapPath("~/TransformXSLT.xsl");
     
    //assigning the path to start read all MenuItem under MenuItems
     xmlDataSource.XPath = "MenuItems/MenuItem";
     
    //Finally, bind the source to the Menu1 control
     Menu1.DataSource = xmlDataSource;
     Menu1.DataBind();
     }
     
    }
    }
