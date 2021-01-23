     protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
     {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = e.Item as GridDataItem;
                    item["XmlColumn1"].Text = Server.HtmlEncode(item["XmlColumn1"].Text);
                    item["XmlColumn2"].Text = Server.HtmlEncode(item["XmlColumn2"].Text);
                }
    
      }
