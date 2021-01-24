    //((SimpleDropSink)lvPlaylist.DropSink).ModelCanDrop+= ModelCanDrop;
     private void ModelCanDrop(object sender, ModelDropEventArgs e)
     {
         e.DropSink.Billboard.BackColor = Color.GreenYellow;
         e.DropSink.FeedbackColor = Color.GreenYellow;
         e.InfoMessage = "Hey there";
         e.Handled = true;
         e.Effect = DragDropEffects.Move;
     }
