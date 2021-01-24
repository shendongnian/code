    `private void ctxMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      if (retryContextMenu) return; // If not a valid user click, don't process
      CancelPopup(); // Make context menu go away
      switch (e.ClickedItem.Text)
      {
        case "blah blah blah":
          ...
          break;
        ...
      }
    }`
