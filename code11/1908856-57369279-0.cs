      private void LstBox3_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (lstBox3.SelectedItem == null) return;
            lstBox2.DoDragDrop(lstBox3.SelectedItem, DragDropEffects.All);
        }
        private void LstBox2_DragDrop(object sender, DragEventArgs e)
        {
            
            Point point = lstBox2.PointToClient(new Point(e.X, e.Y));
            int index = lstBox2.IndexFromPoint(point);
            if (index < 0) index = lstBox2.Items.Count - 1;            
            object data1 = lstBox3.SelectedItem;
            lstBox2.Items.RemoveAt(index);
            lstBox2.Items.Insert(index, data1);
            
        }
       
        private void LstBox2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
