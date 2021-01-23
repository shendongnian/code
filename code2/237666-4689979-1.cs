    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var xmlStr = "<?xml version=\"1.0\" encoding=\"utf-8\"?><inspections>   <inspection>    <inspectionid>8</inspectionid>    <databasename>Åker</databasename>    <exported>false</exported>  </inspection> </inspections>";
            var inspections = XElement.Parse(xmlStr);
            XElement inspection = (from elements in inspections.Elements("inspection")
                                   where elements.Element("databasename").Value == Request.QueryString["DbName"]
                                   select elements).FirstOrDefault();
            lblTest.Text = (inspection != null).ToString();
    
        }
    }
