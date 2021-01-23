    void ddlPopulation_DataBound(object sender, EventArgs e) {
      foreach(ListItem Item in ddlPopulation.Items){
        Item.Text = Server.HtmlEncode(Item.Text.Trim());
      }
    }
