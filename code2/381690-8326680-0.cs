    private void GridSplitter_DragCompleted1(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
    {
      SyncRowDefinitions(Grid1, Grid2);
    }
    private void GridSplitter_DragCompleted2(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
    {
      SyncRowDefinitions(Grid2, Grid1);
    }
    private void SyncRowDefinitions(Grid sourceGrid, Grid targetGrid)
    {
      for (int i = 0; i < sourceGrid.RowDefinitions.Count; i++)
      {
        targetGrid.RowDefinitions[i].Height = sourceGrid.RowDefinitions[i].Height;
      }
    }
