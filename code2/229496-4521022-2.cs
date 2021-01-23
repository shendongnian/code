    private static void List_MouseMove(MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            if (e.Source != null)
            {
                DragDrop.DoDragDrop((ListView)e.Source, (ListView)e.Source, DragDropEffects.Move);
            }
        }
    }
