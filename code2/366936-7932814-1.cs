        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsActiveDragSource)
            {
                // Initialize the drag drop operation
                DragDrop.DoDragDrop(this, this, DragDropEffects.Copy);
            }
        }
