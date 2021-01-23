    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Web.UI;
    using Composite.Data;
    using Composite.Core.Xml;
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fieldKey = "SomeKeyHere";
            string xhtmlString;
    
            using( var connection = new DataConnection())
            {
                xhtmlString = connection.Get<Maw.Content>().Where(f => f.FieldKey == fieldKey).Select(f => f.FieldContent).FirstOrDefault();
            }
    
            if (xhtmlString != null)
            {
                XhtmlDocument htmlDoc = XhtmlDocument.Parse(xhtmlString);
                foreach (XNode bodyNode in htmlDoc.Body.Nodes())
                {
                    this.Controls.Add( new LiteralControl(bodyNode.ToString()));
                }
            }
            else
            {
                this.Controls.Add(new LiteralControl("Unknown FieldKey: " + fieldKey));            
            }
    
        }
    }
