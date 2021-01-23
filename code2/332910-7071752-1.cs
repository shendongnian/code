    void ddlPopulation_DataBound(object sender, EventArgs e) {
      foreach(ListItem Item in ddlPopulation.Items){
        Item.Text = Server.HtmlDecode(Item.Text.Trim());
      }
    }
