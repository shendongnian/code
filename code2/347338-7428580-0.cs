    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace DropDownListBinding
    {
        public partial class Index : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                binddrop();
            }
    
            public void binddrop()
            {
                // this is the collection that will be bound to the DDL
                var userdetailsCollection = new List<object>();
    
                // generate some userdetails and add them to the collection
                for (var i = 0; i < 3; i++)
                {
                    var userdetails = new
                    {
                        Name = "User" + i,
                        ID = i.ToString()
                    };
                    userdetailsCollection.Add(userdetails);
                }
    
                // now we can bind the DDL to the collection
                drpvendor.DataSource = userdetailsCollection;
                drpvendor.DataTextField = "Name";
                drpvendor.DataValueField = "ID";
                drpvendor.DataBind();
    
                drpvendor.Items.Insert(0, new ListItem("-Select Vendor-", "0"));
            }
        }
    }
