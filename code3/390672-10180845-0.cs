    protected void Button_ItemCommand(object source, RepeaterCommandEventArgs e) {
      if (e.CommandName == "Edit") {
        // I need to get my listItem.Id here
        RenderEditDialog(FetchFromStorage(e.CommandArgument.ToString());
      }
    }
