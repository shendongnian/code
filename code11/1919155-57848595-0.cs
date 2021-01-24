        private void SongsListView_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            for(int i = 0; i < sender.Items.Count; i++)
            {
                var container = sender.ContainerFromIndex(i) as ListViewItem;
                container.Background = i % 2 == 0 ? Helper.WhiteSmokeBrush : Helper.WhiteBrush;
            }
        }
