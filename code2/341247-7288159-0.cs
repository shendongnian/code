    void listView__DragOver(object sender, DragEventArgs e)
         {
             if (!e.Data.GetDataPresent("Images"))
             {
                 e.Effects = DragDropEffects.None;
                 e.Handled = true;
             }
         }
