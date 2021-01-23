    void Button_Click(Object sender, EventArgs e)
    {
      // Find the node specified by the user.
      TreeNode node = LinksTreeView.FindNode(Server.HtmlEncode(ValuePathText.Text));
      if (node != null)
      {
        // Indicate that the node was found.
        Message.Text = "The specified node (" + node.ValuePath + ") was found.";
      }
      else
      {
        // Indicate that the node is not in the TreeView control.
        Message.Text = "The specified node (" + ValuePathText.Text + ") is not in this TreeView control.";
      }
    }
