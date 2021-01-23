    private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e) {
      Color nodeColor = Color.Red;
      if ((e.State & TreeNodeStates.Selected) != 0)
        nodeColor = SystemColors.HighlightText;
  
      TextRenderer.DrawText(e.Graphics,
                            e.Node.Text,
                            e.Node.NodeFont,
                            e.Bounds,
                            nodeColor,
                            Color.Empty,
                            TextFormatFlags.VerticalCenter);
    }
