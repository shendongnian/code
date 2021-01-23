    using System;
    using System.Linq;
    using System.Xml.Linq;
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var service = new net.webservicex.www.country();
                var xml = service.GetCountries();
                var countries = XDocument.Parse(xml).Descendants("Name").Select(arg => arg.Value).ToList();
                countriesDropDownList.DataSource = countries;
                countriesDropDownList.DataBind();
            }
        }
    }
