    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["items"] != null)
        {
            var items = Request["items"].ToString(); // Get the JSON string
            JArray o = JArray.Parse(items); // It is an array so parse into a JArray
            var a = o.SelectToken("[0].name").ToString(); // Get the name value of the 1st object in the array
            // a == "Charles"
        }
    }
    }
