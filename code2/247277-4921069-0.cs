    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Default4 : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fetch data from database.
        var list = Game.GetAll();
        var query = from c in list
                 select new Data
                 {
                     Column1 = c.Id,
                     MultipleCplumn = c.Title + "(" + c.Year + ")"
                 };
        MultiFieldRBList1.DataSource = query;
        MultiFieldRBList1.DataTextField = "MultipleCplumn";
        MultiFieldRBList1.DataValueField = "Column1";
        MultiFieldRBList1.DataBind();
      
    }
}
public class Data
{
    public int Column1 { get; set; }
    public string MultipleCplumn { get; set; }
}
